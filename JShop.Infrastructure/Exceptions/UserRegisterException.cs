using Microsoft.AspNetCore.Identity;

namespace JShop.Infrastructure.Exceptions
{
    public class UserRegisterException : ApplicationException
    {
        public UserRegisterException(string? message) : base(message)
        {
        }
    }
}
