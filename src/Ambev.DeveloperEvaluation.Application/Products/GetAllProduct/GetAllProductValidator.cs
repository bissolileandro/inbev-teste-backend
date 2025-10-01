using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProduct
{
    /// <summary>
    /// Validator for GetAllProductCommand
    /// </summary>
    public class GetAllProductValidator : AbstractValidator<GetAllProductCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetAllProductCommand
        /// </summary>
        public GetAllProductValidator()
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
