using System;
using Microsoft.AspNetCore.Mvc;
using ProductServer.ApiModels;
using Microsoft.AspNetCore.Authorization;
using ProductServer.Helpers;
using ProductServer.Services;
using System.Security.Claims;
using ProductServer.Repositories;
using ProductServer.Models;

namespace ProductServer
{
  [ApiController]
  [Route("api/auth")]
  [Authorize]
  public class AuthController : ControllerBase
  {
    public AuthController(AuthService auth, IUnitOfWork worker)
    {
      this.auth = auth;
      this.worker = worker;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(LoginRequest body)
    {
      AuthTokenDto tokens = auth.CreateJwtToken(new Models.User()
      {
        ID = Guid.NewGuid(),
        DisplayName = body.DisplayName
      });

      return Ok(ApiHelper.Success(tokens));
    }

    [HttpPost("refresh")]
    public IActionResult RefreshToken([FromQuery(Name = "token")] string value)
    {
      // verify provided value
      VerifyTokenResult result = auth.VerifyRefreshToken(value, out Auth token);
      if (result != VerifyTokenResult.OK)
        return BadRequest(ApiHelper.Failure(
          result == VerifyTokenResult.UNIDENTIFIED ? "unidentified_refresh_token" : "activated_refresh_token",
          "provided token is invalid",
          new { Value = value }
        ));
      auth.ActivateRefreshToken(token);

      // generate new pair of access token and refresh token
      var dto = auth.CreateJwtToken(token.User);
      auth.StoreRefreshToken(new Auth() { UserID = token.User.ID, RefreshToken = dto.RefreshToken });
      return Ok(ApiHelper.Success(dto));
    }

    private AuthService auth;

    private readonly IUnitOfWork worker;
  }


}
