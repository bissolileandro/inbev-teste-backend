using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsSales.UpdateProductSale
{
    /// <summary>
    /// Represents a request to create a new branch in the system.
    /// </summary>
    public class UpdateProductSaleRequest
    {
        /// <summary>
        /// GetProductSale id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Sale identifier.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Product identifier.
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Qauntity of the product sold.
        /// </summary>
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Unit Price of the product sold.
        /// </summary>
        public decimal UnitPrice { get; set; } = 0;
        /// <summary>
        /// Discount of the product sold.
        /// </summary>
        public decimal Discount { get; set; } = 0;
        /// <summary>
        /// Total of the product sold.
        /// </summary>
        public decimal TotalItem { get; set; } = 0;
        /// <summary>
        /// Status of the product sale.
        /// </summary>
        public ProductSaleStatus Status { get; set; }
    }
}
