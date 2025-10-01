using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    /// <summary>
    /// Validator for GetSaleRequest that defines validation rules for branch retrieval requests.
    /// </summary>
    public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the GetSaleRequestValidator with defined validation rules.
        /// </summary>
        public GetSaleRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
        }
    }
}
