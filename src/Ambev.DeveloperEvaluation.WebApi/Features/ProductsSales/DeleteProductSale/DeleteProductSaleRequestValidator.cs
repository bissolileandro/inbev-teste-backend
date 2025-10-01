using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsSales.DeleteProductSale
{
    /// <summary>
    /// Validator for DeleteProductSaleRequest that defines validation rules for branch deletion requests.
    /// </summary>
    public class DeleteProductSaleRequestValidator : AbstractValidator<DeleteProductSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the DeleteProductSaleRequestValidator with defined validation rules.
        /// </summary>
        public DeleteProductSaleRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product Sale ID is required");
        }
    }
}
