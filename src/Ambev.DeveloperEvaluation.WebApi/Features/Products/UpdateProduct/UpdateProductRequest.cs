using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct
{
    /// <summary>
    /// Represents a request to create a new branch in the system.
    /// </summary>
    public class UpdateProductRequest
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
