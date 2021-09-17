using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductServer.Models;

namespace ProductServer.Services
{
  public class AuthService
  {
    public AuthService(IConfiguration configuration)
    {
      secret = configuration["JwtConfig:Secret"];
      audience = configuration["JwtConfig:Audience"];
      issuer = configuration["JwtConfig:Issuer"];
      generator = SHA512.Create();
    }

    public AuthToken CreateJwtToken(User user)
    {
      long iat = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
      var handler = new JwtSecurityTokenHandler();

      var descriptor = new SecurityTokenDescriptor()
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Actor, user.ID.ToString()),
        }),
        IssuedAt = DateTime.UtcNow,
        Audience = audience,
        Issuer = issuer,
        Expires = DateTime.UtcNow.AddSeconds(EXPIRATION_DURATION),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)), SecurityAlgorithms.HmacSha512)
      };

      var token = handler.CreateToken(descriptor);

      var refresh = generator.ComputeHash(Guid.NewGuid().ToByteArray());

      return new AuthToken
      {
        AccessToken = handler.WriteToken(token),
        RefreshToken = Convert.ToBase64String(refresh)
      };
    }

    public bool VerifyRefreshToken(string value)
    {
      return true;
    }

    public const double EXPIRATION_DURATION = 60 * 15;
    private readonly string secret;
    private readonly string audience;
    private readonly string issuer;
    private SHA512 generator;
  }

  public class AuthToken
  {
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
  }

  public class AccessToken
  {
    public Guid Sub { get; set; }
    public long Iat { get; set; }
    public long Exp { get; set; }
    public string Rol { get; set; }

  }
}