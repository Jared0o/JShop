using FluentValidation;
using JShop.Infrastructure.Dto.Auth;

namespace JShop.Infrastructure.Validators
{
    internal class RegisterValidator : AbstractValidator<AuthRegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} must be valid");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MinimumLength(8).WithMessage("Minimal length for {PropertyName} is {MinLength}. You entered {TotalLength} characters")
                .Matches("[A-Z]").WithMessage("{PropertyName} must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("{PropertyName} must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("{PropertyName} must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("{PropertyName} must contain one or more special characters.")
                .Matches("^[^£# “”]*$").WithMessage("{PropertyName} must not contain the following characters £ # “” or spaces.");

            RuleFor(u => u.Password).Equal(x=> x.PasswordConfirm).WithMessage("Passwords do not match");
        }

    }
}

