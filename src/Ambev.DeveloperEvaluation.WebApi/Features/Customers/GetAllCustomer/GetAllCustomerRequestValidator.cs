using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetAllCustomer
{
    /// <summary>
    /// Validator for GetAllCustomerRequest
    /// </summary>
    public class GetAllCustomerRequestValidator : AbstractValidator<GetAllCustomerRequest>
    {
        /// <summary>
        /// Initializes validation rules for GetAllCustomerRequest
        /// </summary>
        public GetAllCustomerRequestValidator()
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
