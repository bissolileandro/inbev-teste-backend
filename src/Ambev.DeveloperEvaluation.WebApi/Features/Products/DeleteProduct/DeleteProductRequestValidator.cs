using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct
{
    /// <summary>
    /// Validator for DeleteProductRequest that defines validation rules for branch deletion requests.
    /// </summary>
    public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the DeleteProductRequestValidator with defined validation rules.
        /// </summary>
        public DeleteProductRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required");
        }
    }
}
