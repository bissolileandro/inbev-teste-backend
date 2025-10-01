using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.DeleteCustomer
{
    /// <summary>
    /// Validator for DeleteCustomerRequest that defines validation rules for branch deletion requests.
    /// </summary>
    public class DeleteCustomerRequestValidator : AbstractValidator<DeleteCustomerRequest>
    {
        /// <summary>
        /// Initializes a new instance of the DeleteCustomerRequestValidator with defined validation rules.
        /// </summary>
        public DeleteCustomerRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Customer ID is required");
        }
    }
}
