namespace JShop.Infrastructure.Exceptions
{
    public class BadPasswordException : ApplicationException
    {
        public BadPasswordException(string? message) : base(message)
        {
        }
    }
}
