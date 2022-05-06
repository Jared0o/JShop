using FluentValidation;
using JShop.Infrastructure.Dto.Tax;

namespace JShop.Infrastructure.Validators
{
    internal class TaxValidator : AbstractValidator<TaxRequest>
    {
        public TaxValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(20);
            RuleFor(x => x.Value).NotNull().NotEmpty();
        }
    }
}
