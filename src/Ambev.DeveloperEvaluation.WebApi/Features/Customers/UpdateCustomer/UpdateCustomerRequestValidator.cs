using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer
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
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateCustomerValidator with defined validation rules.
        /// </summary>
        public UpdateCustomerRequestValidator()
        {
            RuleFor(customer => customer.Id)
                .NotEmpty().WithMessage("Customer ID cannot be empty.")
                .GreaterThan(0).WithMessage("Customer ID must be greater than zero.");
            RuleFor(customer => customer.Email).SetValidator(new EmailValidator());

            RuleFor(customer => customer.Phone).SetValidator(new PhoneValidator());

            RuleFor(customer => customer.Name)
                .NotEmpty().WithMessage("customer name cannot be empty.")
                .MinimumLength(3).WithMessage("customer name must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("customer name cannot be longer than 100 characters.");
        }
    }
}
