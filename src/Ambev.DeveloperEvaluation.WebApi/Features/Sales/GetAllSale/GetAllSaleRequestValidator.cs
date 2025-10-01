using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSale
{
    /// <summary>
    /// Validator for GetAllSaleRequest
    /// </summary>
    public class GetAllSaleRequestValidator : AbstractValidator<GetAllSaleRequest>
    {
        /// <summary>
        /// Initializes validation rules for GetAllSaleRequest
        /// </summary>
        public GetAllSaleRequestValidator()
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
