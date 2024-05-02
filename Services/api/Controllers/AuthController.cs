using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterRequest request)
        {
            try
            {
                _userService.Register(request.Username, request.Password);
                return Ok(new { message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            try
            {
                bool success = _userService.Login(request.Username, request.Password);
                if (success)
                {
                    return Ok(new { message = "Login successfully" });
                }
                else
                {
                    return Unauthorized(new { message = "Invalid credentials" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

public class UserRegisterRequest
{
    public string Username { get; set;}
    public string Password { get; set;}
}

public class UserLoginRequest
{
    public string Username { get; set;}
    public string Password { get; set;}
}