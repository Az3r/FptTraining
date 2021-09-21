using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductServer.Models;

namespace ProductServer.Services
{
  public interface IAuthService
  {
    string CreateJwtToken(User user);
    string GenerateRandomToken();

    string HashPassword(string password, string name);
  }

  public class AuthService : IAuthService
  {
    public AuthService(IConfiguration configuration)
    {
      secret = configuration["JwtConfig:Secret"];
      audience = configuration["JwtConfig:Audience"];
      issuer = configuration["JwtConfig:Issuer"];
    }

    public string HashPassword(string password, string name)
    {
      byte[] salt = Encoding.ASCII.GetBytes(name);
      byte[] pwd = Encoding.ASCII.GetBytes(password);
      using (var key = new Rfc2898DeriveBytes(password, salt))
      {
        byte[] hashed = key.GetBytes(64);
        return Convert.ToBase64String(hashed);
      }
    }

    public string CreateJwtToken(User user)
    {
      var descriptor = new SecurityTokenDescriptor()
      {
        Claims = new Dictionary<string, object>()
        {
          { "actor", user.ID.ToString() },
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