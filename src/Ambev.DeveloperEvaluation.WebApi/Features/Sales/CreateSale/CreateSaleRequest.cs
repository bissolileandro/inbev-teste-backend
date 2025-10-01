using Ambev.DeveloperEvaluation.Application.ProductsSales.CreateProductSale;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Represents a request to create a new branch in the system.
    /// </summary>
    public class CreateSaleRequest
    {
        /// <summary>
        /// Date of the sale.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Identifier of the customer who made the purchase.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for a branch.
        /// </summary>
        public int BranchId { get; set; }

        /// <summary>
        /// Gets or sets the collection of product sales associated with this entity.
        /// </summary>
        public virtual List<CreateProductSaleCommand> ProductsSales { get; set; } = new List<CreateProductSaleCommand>();

        /// <summary>
        /// Gets or sets the total amount of discounts applied to the current transaction.
        /// </summary>
        public decimal TotalDiscounts { get; set; } = 0;

        /// <summary>
        /// Gets or sets the total quantity of items sold.
        /// </summary>
        public decimal TotalQuantities { get; set; } = 0;

        /// <summary>
        /// Gets or sets the total amount of items sold.
        /// </summary>
        public decimal TotalAmount { get; set; } = 0;

        /// <summary>
        /// Gets or sets the current status of the sale.
        /// </summary>
        public SaleStatus Status { get; set; }
    }
}
