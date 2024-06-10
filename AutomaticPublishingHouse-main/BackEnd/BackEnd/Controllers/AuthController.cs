using BackEnd.Models.Auth;
using BLL;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly AuthService _authService;

        public AuthController(TokenService tokenService,
            AuthService authService)
        {
            _tokenService = tokenService;
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _authService.Authenticate(model.Login, model.Password);
            
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var accessToken = new AccessTokenModel() { Token = _tokenService.GenerateJwtToken(user) };
            return Ok(accessToken);
        }

        [HttpPost("register")]
        public IActionResult Regiser([FromBody] RegisterModel model)
        {
            var user = _authService.Register(model.Login, model.Name, model.Password, model.Role);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            var accessToken = new AccessTokenModel() { Token = _tokenService.GenerateJwtToken(user) };

            return Ok(accessToken);
        }
    }
}
