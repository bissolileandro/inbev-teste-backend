using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer
{
    /// <summary>
    /// Validator for GetCustomerRequest that defines validation rules for branch retrieval requests.
    /// </summary>
    public class GetCustomerRequestValidator : AbstractValidator<GetCustomerRequest>
    {
        /// <summary>
        /// Initializes a new instance of the GetCustomerRequestValidator with defined validation rules.
        /// </summary>
        public GetCustomerRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Customer ID is required");
        }
    }
}
