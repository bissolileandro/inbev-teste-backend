using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer
{
    /// <summary>
    /// Validator for GetCustomerCommand that defines validation rules for retrieving a branch by ID.
    /// </summary>
    public class GetCustomerValidator : AbstractValidator<GetCustomerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the GetCustomerValidator with defined validation rules.
        /// </summary>
        public GetCustomerValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Customer ID is required")
            .GreaterThan(0).WithMessage("Customer Id must be greater than zero."); ;
        }
    }
}
