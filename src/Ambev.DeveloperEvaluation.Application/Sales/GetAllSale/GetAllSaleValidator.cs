using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSale
{
    /// <summary>
    /// Validator for GetAllSaleCommand
    /// </summary>
    public class GetAllSaleValidator : AbstractValidator<GetAllSaleCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetAllSaleCommand
        /// </summary>
        public GetAllSaleValidator()
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
