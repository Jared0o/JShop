namespace JShop.Infrastructure.Dto.Auth
{
    public class AuthResponse
    {
        public string Token { get; set; }

        public AuthResponse(string token)
        {
            Token = token;
        }
    }
}
