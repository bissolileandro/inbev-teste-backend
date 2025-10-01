using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerResponse>
    {
        /// <summary>
        /// Identifier of the customer to be deleted.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCustomerCommand"/> class.
        /// </summary>
        /// <param name="id"></param>
        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
