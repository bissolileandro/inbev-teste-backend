using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProduct
{
    /// <summary>
    /// Validator for GetAllProductRequest
    /// </summary>
    public class GetAllProductRequestValidator : AbstractValidator<GetAllProductRequest>
    {
        /// <summary>
        /// Initializes validation rules for GetAllProductRequest
        /// </summary>
        public GetAllProductRequestValidator()
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
