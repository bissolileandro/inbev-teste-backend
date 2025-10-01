using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductResponse>
    {
        /// <summary>
        /// Identifier of the product to be deleted.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteProductCommand"/> class.
        /// </summary>
        /// <param name="id"></param>
        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
