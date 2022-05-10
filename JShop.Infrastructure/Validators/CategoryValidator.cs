using FluentValidation;
using JShop.Infrastructure.Dto.Category;

namespace JShop.Infrastructure.Validators
{
    internal class CategoryValidator : AbstractValidator<CategoryRequest>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(20);
            RuleFor(x => x.Description).NotEmpty().NotNull().MaximumLength(255);
        }
    }
}
