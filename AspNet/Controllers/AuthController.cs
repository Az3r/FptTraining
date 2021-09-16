using System;
using Microsoft.AspNetCore.Mvc;
using JWT.Builder;
using JWT.Algorithms;
using Microsoft.Extensions.Configuration;
using ProductServer.ApiModels;

namespace ProductServer
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser(CreateUserRequest body)
        {
            return Created(Guid.NewGuid().ToString(), body);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest body)
        {
            long iat = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var json = JwtBuilder.Create()
                .WithAlgorithm(new HMACSHA512Algorithm())
                .AddClaim("sub", Guid.NewGuid())
                .AddClaim("name", body.DisplayName)
                .AddClaim("rol", "NOT_IMPLEMENTED")
                .AddClaim("aud", "ASP.NET Product Server")
                .AddClaim("iat", iat)
                .AddClaim("exp", iat + 60 * 5)
                .WithSecret(configuration["DotEnv:JwtSecret"]);

            return Ok();
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken()
        {
            throw new NotImplementedException(nameof(RefreshToken));
        }

        private IConfiguration configuration;
    }


}
