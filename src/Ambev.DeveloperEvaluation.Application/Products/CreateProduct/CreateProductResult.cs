using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductResult
    {
        /// <summary>
        /// Product id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get Description of the product.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Get Price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets the Product status.        
        /// </summary>
        public ProductStatus Status { get; set; }
    }
}
