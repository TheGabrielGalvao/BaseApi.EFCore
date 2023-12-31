﻿using Domain.Interface.Service.Auth;
using Domain.Model.Auth;
using Microsoft.AspNetCore.Mvc;

namespace DinheirusAPI.Controllers.v2
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest request)
        {
            var authResult = await _authService.ExecuteAuth(request);

            if (authResult.Success)
            {
                return Ok(new { Token = authResult.AccessToken });
            }

            return Unauthorized();
        }
    }
}
