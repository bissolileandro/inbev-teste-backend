using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct
{
    /// <summary>
    /// Validator for CreateCustomerCommand that defines validation rules for Customer creation command.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)    
    /// - Phone: Must match international (using Phonevalidator)    
    /// - Name: Cannot be set to None
    /// </remarks>
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateCustomerValidator with defined validation rules.
        /// </summary>
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required")
            .GreaterThan(0).WithMessage("Product Id must be greater than zero.");

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
