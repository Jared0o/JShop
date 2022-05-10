using FluentValidation;
using JShop.Infrastructure.Dto.Brand;

namespace JShop.Infrastructure.Validators
{
    internal class BrandValidator : AbstractValidator<BrandRequest>
    {
        public BrandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(20);
            RuleFor(x => x.Description).MaximumLength(255);
        }
    }
}
