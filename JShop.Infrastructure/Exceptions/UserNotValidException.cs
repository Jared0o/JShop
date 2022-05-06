namespace JShop.Infrastructure.Exceptions
{
    public class UserNotValidException : ApplicationException
    {
        public UserNotValidException(string? message) : base(message)
        {
        }
    }
}
