using JShop.Infrastructure.Dto.Auth;
using JShop.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JShop.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(AuthRegisterRequest request)
        {
            var response = await _authService.RegisterUserAsync(request);

            return Ok(response);    
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthLoginRequest request)
        {
            var response = await _authService.LoginUserAsync(request);

            return Ok(response);
        }
    }
}
