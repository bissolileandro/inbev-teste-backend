using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Customer : BaseEntity<int>
    {        
        /// <summary>
        /// Customer's full name.
        /// </summary>
        public string Name { get; set; } = string.Empty;        

        /// <summary>
        /// Gets the customers email address.        
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets the customers phone number.        
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collection of sales associated with this entity.
        /// </summary>
        public virtual List<Sale>? Sales { get; set; }

        /// <summary>
        /// Gets the customer status.        
        /// </summary>
        public CustomerStatus Status { get; set; }

        /// <summary>
        /// Activates the customer.
        /// Changes the customer's status to Active.
        /// </summary>
        public void Activate()
        {
            Status = CustomerStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Deactivates the customer.
        /// Changes the customer's status to Inactive.
        /// </summary>
        public void Deactivate()
        {
            Status = CustomerStatus.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Performs validation on the current Customer entity instance.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>        
        /// <list type="bullet">Email format</list>
        /// <list type="bullet">Phone number format</list>
        /// <list type="bullet">Name Empty or Minimum and Maximoum Length</list>        
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new CustomerValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public Customer()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
