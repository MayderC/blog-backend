using AutoMapper;
using BlogCore.Entities;
using BlogCore.Ports.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using BlogApplication.DTOs.Auth;
using BlogApplication.Helpers;


namespace BlogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = _authService.Login(_mapper.Map<User>(request));
                if (user == null)
                    return BadRequest(new LoginResponse(false, "", ""));

                var jwt = new JsonWebToken("secret secret secret secret secret secret secret");
                var token = jwt.CreateToken(user);
                var refresh = jwt.CreateRefreshToken(user);
                return Ok(new LoginResponse(true, token, refresh));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("register")]
        public ActionResult<string> Register([FromBody] RegisterRequest user)
        {
            try
            {
                _authService.Register(_mapper.Map<User>(user));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
