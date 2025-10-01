using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer
{
    /// <summary>
    /// UpdateCustomerValidator is responsible for validating the UpdateCustomerCommand.
    /// </summary>
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateCustomerValidator with defined validation rules.
        /// </summary>
        public UpdateCustomerValidator()
        {
            RuleFor(Customer => Customer.Id)
                .NotEmpty().WithMessage("Customer ID cannot be empty.")
                .GreaterThan(0).WithMessage("Customer ID must be greater than zero.");    

            RuleFor(Customer => Customer.Email).SetValidator(new EmailValidator());

            RuleFor(Customer => Customer.Phone).SetValidator(new PhoneValidator());

            RuleFor(Customer => Customer.Name)
                .NotEmpty().WithMessage("Customer name cannot be empty.")
                .MinimumLength(3).WithMessage("Customer name must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Customer name cannot be longer than 100 characters.");
        }
    }
}
