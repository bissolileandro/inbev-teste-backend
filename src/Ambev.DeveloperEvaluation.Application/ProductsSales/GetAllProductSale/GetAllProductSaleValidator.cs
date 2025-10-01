using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.GetAllProductSale
{
    /// <summary>
    /// Validator for GetAllProductSaleCommand
    /// </summary>
    public class GetAllProductSaleValidator : AbstractValidator<GetAllProductSaleCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetAllProductSaleCommand
        /// </summary>
        public GetAllProductSaleValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("The page number must be greater than zero.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("Page size must be greater than zero.");                
        }
    }
}
