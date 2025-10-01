using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.GetProductSale
{
    /// <summary>
    /// Command to get a product by Id.
    /// </summary>
    public class GetProductSaleCommand : IRequest<GetProductSaleResult>
    {
        /// <summary>
        /// Get or set the Id of the product to be retrieved.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the products name.
        /// </summary>
        /// <param name="id"></param>
        public GetProductSaleCommand(int id)
        {
            Id = id;
        }
    }
}
