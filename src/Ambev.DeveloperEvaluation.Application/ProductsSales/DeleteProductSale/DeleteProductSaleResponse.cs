using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.DeleteProductSale
{
    /// <summary>
    /// Represents the response after deleting a product.
    /// </summary>
    public class DeleteProductSaleResponse
    {
        /// <summary>
        /// Indicates whether the product deletion was successful.
        /// </summary>
        public bool Success { get; set; }
    }
}
