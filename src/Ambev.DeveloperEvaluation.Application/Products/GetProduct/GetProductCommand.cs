using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    /// <summary>
    /// Command to get a product by Id.
    /// </summary>
    public class GetProductCommand : IRequest<GetProductResult>
    {
        /// <summary>
        /// Get or set the Id of the product to be retrieved.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the products name.
        /// </summary>
        /// <param name="id"></param>
        public GetProductCommand(int id)
        {
            Id = id;
        }
    }
}
