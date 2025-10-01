using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.DeleteProductSale
{
    public class DeleteProductSaleCommand : IRequest<DeleteProductSaleResponse>
    {
        /// <summary>
        /// Identifier of the product sale to be deleted.
        /// </summary>
        public int Id { get; set; }
        

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteProductSaleCommand"/> class.
        /// </summary>
        /// <param name="id"></param>
        public DeleteProductSaleCommand(int id)
        {
            Id = id;            
        }
    }
}
