using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.DeleteProductSale
{
    /// <summary>
    /// Validator for DeleteProductSaleCommand
    /// </summary>
    public class DeleteProductSaleValidator : AbstractValidator<DeleteProductSaleCommand>
    {
        /// <summary>
        /// Initializes validation rules for DeleteProductSaleCommand
        /// </summary>
        public DeleteProductSaleValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("ProductSale ID is required");            
        }
    }
}
