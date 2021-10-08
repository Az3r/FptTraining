using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductServer.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace ProductServer.Services
{
  public interface IAuthService
  {
    string CreateJwtToken(User user);
    string GenerateRandomToken();

    byte[] HashPassword(string password, out byte[] salt);
    bool VerifyPassword(string password, byte[] expected, byte[] salt);
  }

  public class AuthService : IAuthService
  {
    public AuthService(IConfiguration configuration)
    {
      secret = configuration["JwtConfig:Secret"];
      audience = configuration["JwtConfig:Audience"];
      issuer = configuration["JwtConfig:Issuer"];

    }

    public byte[] HashPassword(string password, out byte[] salt)
    {
      salt = new byte[32];
      using (var generator = new RNGCryptoServiceProvider())
      {
        generator.GetNonZeroBytes(salt);
      }

      byte[] hashed = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 1000, 64);

      return hashed;
    }

    public bool VerifyPassword(string password, byte[] expected, byte[] salt)
    {
      byte[] actual = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 10000, 64);

      bool matched = CryptographicOperations.FixedTimeEquals(actual, expected);
      return matched;
    }

    public string CreateJwtToken(User user)
    {
      var descriptor = new SecurityTokenDescriptor()
      {
        Claims = new Dictionary<string, object>()
        {
          { "actor", user.ID.ToString() },
          { "rol", "user" },
        },
        IssuedAt = DateTime.UtcNow,
        Audience = audience,
        Issuer = issuer,
        Expires = DateTime.UtcNow.AddSeconds(TOKEN_DURATION),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)), SecurityAlgorithms.HmacSha512)
      };

      var token = handler.CreateToken(descriptor);
      return handler.WriteToken(token);
    }

    public string GenerateRandomToken()
    {
      Random random = new Random();
      byte[] buffer = new byte[64];
      random.NextBytes(buffer);
      string hash = Convert.ToBase64String(buffer);
      return hash;
    }

    public const double TOKEN_DURATION = 60 * 5;             // 5 minutes 
    private readonly string secret;
    private readonly string audience;
    private readonly string issuer;
    private JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
  }
}