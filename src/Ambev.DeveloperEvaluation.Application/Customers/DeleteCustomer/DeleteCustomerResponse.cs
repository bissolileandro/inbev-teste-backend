using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer
{
    /// <summary>
    /// Represents the response after deleting a customer.
    /// </summary>
    public class DeleteCustomerResponse
    {
        /// <summary>
        /// Indicates whether the customer deletion was successful.
        /// </summary>
        public bool Success { get; set; }
    }
}
