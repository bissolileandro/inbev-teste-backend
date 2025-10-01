using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsSales.GetProductSale
{
    /// <summary>
    /// Validator for GetProductSaleRequest that defines validation rules for branch retrieval requests.
    /// </summary>
    public class GetProductSaleRequestValidator : AbstractValidator<GetProductSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the GetProductSaleRequestValidator with defined validation rules.
        /// </summary>
        public GetProductSaleRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product Sale ID is required");
        }
    }
}
