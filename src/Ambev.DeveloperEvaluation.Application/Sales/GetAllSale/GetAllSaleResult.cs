using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.ProductsSales.CreateProductSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSale
{
    public class GetAllSaleResult
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
        public virtual CreateCustomerResult Customer { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for a branch.
        /// </summary>
        public int BranchId { get; set; }
        public virtual CreateBranchResult Branch { get; set; }

        /// <summary>
        /// Gets or sets the collection of product sales associated with this entity.
        /// </summary>
        public virtual List<CreateProductSaleResult> ProductsSales { get; set; } = new List<CreateProductSaleResult>();

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
