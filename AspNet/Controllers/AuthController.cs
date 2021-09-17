using System;
using Microsoft.AspNetCore.Mvc;
using ProductServer.ApiModels;
using Microsoft.AspNetCore.Authorization;
using ProductServer.Helpers;
using ProductServer.Services;

namespace ProductServer
{
  [ApiController]
  [Route("api/auth")]
  [Authorize(AuthenticationSchemes = "Bearer")]
  public class AuthController : ControllerBase
  {
    public AuthController(AuthService auth)
    {
      this.auth = auth;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(LoginRequest body)
    {
      AuthToken tokens = auth.CreateJwtToken(new Models.User
      {
        ID = Guid.NewGuid(),
        DisplayName = body.DisplayName
      });

      return Ok(ApiHelper.Success(tokens));
    }

    [HttpPost("refresh")]
    public IActionResult RefreshToken(string value)
    {
      bool valid = auth.VerifyRefreshToken(value);

      return Ok();
    }

    private AuthService auth;
  }


}
