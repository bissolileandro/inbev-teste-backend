using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleCommand : IRequest<DeleteSaleResponse>
    {
        /// <summary>
        /// Identifier of the sale to be deleted.
        /// </summary>
        public int Id { get; set; }
        

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSaleCommand"/> class.
        /// </summary>
        /// <param name="id"></param>
        public DeleteSaleCommand(int id)
        {
            Id = id;            
        }
    }
}
