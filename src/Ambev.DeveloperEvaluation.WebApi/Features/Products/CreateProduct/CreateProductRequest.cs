using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Represents a request to create a new branch in the system.
    /// </summary>
    public class CreateProductRequest
    {
        /// <summary>
        /// Get Description of the product.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Get Price of the product.
        /// </summary>
        public decimal Price { get; set; } = 0;

        /// <summary>
        /// Gets or sets the current status of the product.
        /// </summary>
        public ProductStatus Status { get; set; }
    }
}
