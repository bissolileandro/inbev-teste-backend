using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<UpdateCustomerResult>
    {
        /// <summary>
        /// Id of the Customer to be updated.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Customer's name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets the Customer's email address.        
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets the Customer's phone number.        
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Gets the Customer status.        
        /// </summary>
        public CustomerStatus Status { get; set; }

        /// <summary>
        /// Validates the command using the UpdateCustomerValidator.
        /// </summary>
        /// <returns></returns>
        public ValidationResultDetail Validate()
        {
            var validator = new UpdateCustomerValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }


    }
}
