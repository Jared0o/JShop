using FluentValidation;
using JShop.Infrastructure.Dto.Product;

namespace JShop.Infrastructure.Validators
{
    internal class ProductValidator : AbstractValidator<ProductRequest>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.Description).MaximumLength(255);
            RuleFor(x => x.InStock).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotEmpty().NotNull();
        }
    }
}
