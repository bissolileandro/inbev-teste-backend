using Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;
using Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer;
using Ambev.DeveloperEvaluation.Application.ProductsSales.UpdateProductSale;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// Response model for CreateProduct operation
    /// </summary>
    public class UpdateSaleResponse
    {
        /// <summary>
        /// ProductSale id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date of the sale.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Identifier of the customer who made the purchase.
        /// </summary>
        public int CustomerId { get; set; }
        public virtual UpdateCustomerResult Customer { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for a branch.
        /// </summary>
        public int BranchId { get; set; }
        public virtual UpdateBranchResult Branch { get; set; }

        /// <summary>
        /// Gets or sets the collection of product sales associated with this entity.
        /// </summary>
        public virtual List<UpdateProductSaleResult> ProductsSales { get; set; } = new List<UpdateProductSaleResult>();

        /// <summary>
        /// Gets or sets the total amount of discounts applied to the current transaction.
        /// </summary>
        public decimal TotalDiscounts { get; set; }

        /// <summary>
        /// Gets or sets the total quantity of items sold.
        /// </summary>
        public decimal TotalQuantities { get; set; }

        /// <summary>
        /// Gets or sets the total amount of items sold.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the current status of the sale.
        /// </summary>
        public SaleStatus Status { get; set; }
    }
}
