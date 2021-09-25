using System;
using Microsoft.AspNetCore.Mvc;
using ProductServer.ApiModels;
using Microsoft.AspNetCore.Authorization;
using ProductServer.Helpers;
using ProductServer.Services;
using ProductServer.Repositories;
using ProductServer.Models;
using ProductServer.DTOs;

namespace ProductServer
{
  [ApiController]
  [Route("api/auth")]
  [Authorize]
  public class AuthController : ControllerBase
  {
    public AuthController(IAuthService auth, IUnitOfWork worker)
    {
      this.auth = auth;
      this.worker = worker;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(LoginRequest body)
    {
      User user = worker.UserRepository.Find(body.DisplayName);
      if (user is null)
      {
        return NotFound(ApiHelper.Failure("user_not_found", "unable to find user with provided arguments"));
      }

      bool authorized = auth.VerifyPassword(body.Password, user.HashedPassword, user.Salt);

      AuthTokenDto tokens = new AuthTokenDto
      {
        AccessToken = auth.CreateJwtToken(user),
        RefreshToken = auth.GenerateRandomToken()
      };

      worker.AuthRepository.Create(new Auth
      {
        UserID = user.ID,
        ExpirationTime = DateTime.UtcNow.AddDays(30),
        Token = tokens.RefreshToken
      });
      worker.Save();

      return Ok(ApiHelper.Success(tokens));
    }

    [HttpPost("refresh")]
    public IActionResult RefreshToken([FromQuery(Name = "token")] string value)
    {
      // verify provided value
      Auth found = worker.AuthRepository.Find(value);
      if (found is null)
        return NotFound(ApiHelper.Failure(
          "refresh_token_not_found",
          "unable to find provided refresh token"
        ));

      if (found.ActivatedAt is not null) return BadRequest(ApiHelper.Failure(
        "refresh_token_activated",
        "provided refresh token has been activated",
        new
        {
          ActivatedAt = found.ActivatedAt
        }
      ));


      worker.AuthRepository.Activate(found);
      AuthTokenDto tokens = new AuthTokenDto
      {
        AccessToken = auth.CreateJwtToken(new Models.User { ID = found.UserID }),
        RefreshToken = auth.GenerateRandomToken()
      };

      worker.AuthRepository.Create(new Auth
      {
        UserID = found.UserID,
        ExpirationTime = DateTime.UtcNow.AddDays(30),
        Token = tokens.RefreshToken
      });
      worker.Save();

      return Ok(ApiHelper.Success(tokens));
    }

    private IAuthService auth;

    private readonly IUnitOfWork worker;
  }
}
