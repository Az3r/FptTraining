using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductServer.ApiModels;
using ProductServer.Models;
using ProductServer.Repositories;

namespace ProductServer.Services
{
  public class AuthService
  {
    public AuthService(IConfiguration configuration, IUnitOfWork worker)
    {
      secret = configuration["JwtConfig:Secret"];
      audience = configuration["JwtConfig:Audience"];
      issuer = configuration["JwtConfig:Issuer"];
      this.worker = worker;
    }

    public AuthTokenDto CreateJwtToken(User user)
    {
      var accessDescriptor = new SecurityTokenDescriptor()
      {
        Claims = new Dictionary<string, object>()
        {
          { "actor", user.ID.ToString() },
        },
        IssuedAt = DateTime.UtcNow,
        Audience = audience,
        Issuer = issuer,
        Expires = DateTime.UtcNow.AddSeconds(ACCESS_TOKEN_EXP),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)), SecurityAlgorithms.HmacSha512)
      };

      var refreshDescriptor = new SecurityTokenDescriptor()
      {
        Claims = new Dictionary<string, object>()
        {
          { "actor", user.ID.ToString() },
        },
        IssuedAt = DateTime.UtcNow,
        Audience = audience,
        Issuer = issuer,
        Expires = DateTime.UtcNow.AddSeconds(REFRESH_TOKEN_EXP),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)), SecurityAlgorithms.HmacSha256)
      };

      var access = handler.CreateToken(accessDescriptor);
      var refresh = handler.CreateToken(refreshDescriptor);

      return new AuthTokenDto()
      {
        AccessToken = handler.WriteToken(access),
        RefreshToken = handler.WriteToken(refresh),
      };
    }

    public VerifyTokenResult VerifyRefreshToken(string value, out Auth token)
    {
      try
      {
        // validate token
        ClaimsPrincipal principal = handler.ValidateToken(
          value,
          new TokenValidationParameters()
          {
            ValidAlgorithms = new string[] { "HS256" },
            ValidAudience = audience,
            ValidIssuer = issuer,
            ValidateActor = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
          },
          out SecurityToken jwt
        );

        // check if actor claim is in guid format
        bool success = Guid.TryParse(principal.FindFirstValue("actor"), out Guid user);
        if (!success)
        {
          token = null;
          return VerifyTokenResult.UNIDENTIFIED;
        }

        Auth result = worker.AuthRepository.Entities.FirstOrDefault(v =>
          v.RefreshToken.Equals(value, StringComparison.Ordinal) &&
          v.UserID.Equals(user)
        );
        if (result is null || result.ActivatedAt is not null)
        {
          token = null;
          return VerifyTokenResult.UNIDENTIFIED;
        }

        token = result;
        return VerifyTokenResult.OK;

      }
      catch (System.Exception)
      {
        token = null;
        return VerifyTokenResult.UNIDENTIFIED;
      }


    }

    /// <summary>do nothing if token has already been activated</summary>
    public void ActivateRefreshToken(Auth token)
    {
      if (token.ActivatedAt is not null) return;
      token.ActivatedAt = DateTime.UtcNow;
      worker.AuthRepository.Update(token);
      worker.Save();
    }

    public void StoreRefreshToken(Auth token)
    {
      worker.AuthRepository.Create(token);
      worker.AuthRepository.Save();
    }

    public const double ACCESS_TOKEN_EXP = 60 * 5;             // 5 minutes 
    public const double REFRESH_TOKEN_EXP = 60 * 60 * 24 * 30; // 30 days
    private readonly string secret;
    private readonly string audience;
    private readonly string issuer;
    private readonly IUnitOfWork worker;
    private JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
  }

  public enum VerifyTokenResult
  {
    UNIDENTIFIED,
    OK,
    ACTIVATED,

  }

}