using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer
{
    /// <summary>
    /// Command to get a customer by Id.
    /// </summary>
    public class GetCustomerCommand : IRequest<GetCustomerResult>
    {
        /// <summary>
        /// Get or set the Id of the customer to be retrieved.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the customers name.
        /// </summary>
        /// <param name="id"></param>
        public GetCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
