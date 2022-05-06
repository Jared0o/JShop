namespace JShop.Infrastructure.Dto.Auth
{
    public class AuthRegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Name { get; set; }

        public AuthRegisterRequest(string email, string name, string password, string passwordConfirm)
        {
            Email = email;
            Password = password;
            PasswordConfirm = passwordConfirm;
            Name = name;
        }
    }
}
