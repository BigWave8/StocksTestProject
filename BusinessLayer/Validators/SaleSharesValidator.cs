using BusinessLayer.DTOs;
using FluentValidation;

namespace BusinessLayer.Validators
{
    public class SaleSharesValidator : AbstractValidator<SaleSharesDTO>
    {
        public SaleSharesValidator()
        {
            RuleFor(x => x.SharesCount)
                .GreaterThan(0);

            RuleFor(x => x.PricePerShare)
                .GreaterThan(decimal.Zero);
        }
    }
}
