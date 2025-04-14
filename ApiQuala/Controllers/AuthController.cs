using ApiQuala.Core.Domain.Entities;
using ApiQuala.Core.Interfaces;
using ApiQuala.Infraestructure.Security;
using Microsoft.AspNetCore.Mvc;


namespace ApiQuala.Controllers
{

        [Route("api/auth")]
        [ApiController]
        public class AuthController : ControllerBase
        {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        public AuthController(IAuthService authService , IConfiguration config)
            {
            _authService = authService;
            _config = config;
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] Users login)
            {
            Token _token = new Token(_config);
            
            Users resultDb=   _authService.ValidarUsuarioAsync(login.username , login.password).GetAwaiter().GetResult();

            if (resultDb != null)
                {
                    var token = _token.GenerateToken(login.username);
                    return Ok(new { token });
                }
                return Unauthorized();
            }
        }
    
}
