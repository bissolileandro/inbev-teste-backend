using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{
    /// <summary>
    /// Validator for GetProductRequest that defines validation rules for branch retrieval requests.
    /// </summary>
    public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the GetProductRequestValidator with defined validation rules.
        /// </summary>
        public GetProductRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required");
        }
    }
}
