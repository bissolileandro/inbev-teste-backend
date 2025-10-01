using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer
{
    /// <summary>
    /// Represents a request to create a new branch in the system.
    /// </summary>
    public class UpdateCustomerRequest
    {
        /// <summary>
        /// Id of the updated branch.
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
    }
}
