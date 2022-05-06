using AutoMapper;
using JShop.Core.Entities.Identity;
using JShop.Infrastructure.Dto.Auth;
using JShop.Infrastructure.Exceptions;
using JShop.Infrastructure.Services.Interfaces;
using JShop.Infrastructure.Validators;
using Microsoft.AspNetCore.Identity;

namespace JShop.Infrastructure.Services
{
    internal class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _token;
        private readonly SignInManager<User> _signInManager;

        public AuthService(UserManager<User> userManager, ITokenService token, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _token = token;
            _signInManager = signInManager;
        }

        public async Task<AuthResponse> LoginUserAsync(AuthLoginRequest request)
        {
            LoginValidator validator = new LoginValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if(!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            User user = await _userManager.FindByEmailAsync(request.Email);
            if(user == null)
                throw new NotFoundException($"Email {request.Email} does not exists.");

            var checkUserPassword = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);
            if (!checkUserPassword.Succeeded)
                throw new BadPasswordException("Password is incorrect");
            if (checkUserPassword.IsLockedOut)
                throw new BadPasswordException("Account was blocked, please try again later or contact with us aa@aa.com.pl");

            var token = await _token.CreateTokenAsync(user);

            return new AuthResponse(token);

        }

        public async Task<AuthResponse> RegisterUserAsync(AuthRegisterRequest request)
        {
            RegisterValidator validator = new RegisterValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            User user = new User() { Email = request.Email, UserName = request.Email, Name = request.Name};

            var registerResult = await _userManager.CreateAsync(user, request.Password);
            if (!registerResult.Succeeded)
                throw new UserRegisterException("Try again later");

            var resultRoles = await _userManager.AddToRoleAsync(user, BaseRoleEnum.User.ToString());
            if(!resultRoles.Succeeded)
                throw new UserRegisterException("Try again later");

            var token = await _token.CreateTokenAsync(user);

            return new AuthResponse(token);


        }
    }
}
