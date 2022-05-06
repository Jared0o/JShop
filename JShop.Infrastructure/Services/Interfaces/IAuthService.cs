using JShop.Infrastructure.Dto.Auth;

namespace JShop.Infrastructure.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthResponse> RegisterUserAsync(AuthRegisterRequest request);
        public Task<AuthResponse> LoginUserAsync(AuthLoginRequest request);

    }
}
