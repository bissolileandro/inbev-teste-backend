using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetAllCustomer
{
    /// <summary>
    /// Validator for GetAllCustomerCommand
    /// </summary>
    public class GetAllCustomerValidator : AbstractValidator<GetAllCustomerCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetAllCustomerCommand
        /// </summary>
        public GetAllCustomerValidator()
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
