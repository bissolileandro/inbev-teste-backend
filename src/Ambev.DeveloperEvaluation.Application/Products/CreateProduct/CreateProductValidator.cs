using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    /// <summary>
    /// Validator for CreateProductCommand that defines validation rules for product creation command.
    /// </summary>    
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateProductValidator with defined validation rules.
        /// </summary>
        public CreateProductValidator()
        {
            RuleFor(product => product.Description)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Description must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Description cannot be longer than 100 characters.");

            RuleFor(product => product.Price)
                .NotEmpty()
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }
}
