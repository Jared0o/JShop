using JShop.Core.Entities.Identity;

namespace JShop.Infrastructure.Services.Interfaces
{
    public interface ITokenService
    {
        public Task<string> CreateTokenAsync(User user);
    }
}
