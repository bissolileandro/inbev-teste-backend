using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    /// <summary>
    /// Represents the response after deleting a product.
    /// </summary>
    public class DeleteProductResponse
    {
        /// <summary>
        /// Indicates whether the product deletion was successful.
        /// </summary>
        public bool Success { get; set; }
    }
}
