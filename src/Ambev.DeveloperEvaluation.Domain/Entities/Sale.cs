using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity<int>
    {        
        /// <summary>
        /// Date of the sale.
        /// </summary>
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Identifier of the customer who made the purchase.
        /// </summary>
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for a branch.
        /// </summary>
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        
        /// <summary>
        /// Gets or sets the collection of product sales associated with this entity.
        /// </summary>
        public virtual List<ProductSale> ProductsSales { get; set; } = new List<ProductSale>();
        
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

        /// <summary>
        /// Calculates the total quantities, discounts, and amount for the sale.
        /// </summary>
        public void CalculateTotals()
        {
            var discountPercentual = 0.0m;

            //var discountProduct = ProductsSales
            //    .GroupBy(i => i.ProductId)
            //    .Select(g => new ProductSale
            //    {
            //        ProductId = g.Key,
            //        Quantity = g.Sum(x => x.Quantity),
            //        UnitPrice = g.First().UnitPrice,                    
            //    })
            //    .Where(c => c.Status == ProductSaleStatus.Active)
            //    .ToList();

            //foreach (var item in discountProduct)
            //{
            //    if (item.Quantity > 4)
            //    {
                    
            //        item.ApplyTotalItem();  
            //    }
            //}

            foreach (var item in ProductsSales)
            {
                if (item.Quantity > 4)
                {
                    discountPercentual = (item.Quantity >= 10 ? 0.20m : 0.10m);
                    item.ApplyDiscount(discountPercentual);
                }
                item.ApplyTotalItem();                
            }


            TotalQuantities = ProductsSales.Where(c => c.Status == ProductSaleStatus.Active).Sum(i => i.Quantity);
            TotalDiscounts = ProductsSales.Where(c => c.Status == ProductSaleStatus.Active).Sum(i => i.Discount);
            TotalAmount = ProductsSales.Where(c => c.Status == ProductSaleStatus.Active).Sum(i => i.TotalItem);
        }

        /// <summary>
        /// Cancel product of sale.
        /// Changes the sale status to Cancel.
        /// </summary>
        public void Cancel()
        {
            Status = SaleStatus.Canceled;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Active product of sale.
        /// Changes the sale status to Active.
        /// </summary>
        public void Active()
        {
            Status = SaleStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Performs validation on the current Sale entity instance.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>        
        /// <list type="bullet">Sale date cannot be in the future or empty</list>        
        /// <list type="bullet">BranchId must be greater than zero</list>        
        /// <list type="bullet">CustomerId must be greater than zero</list>        
        /// <list type="bullet">Each product sale must be valid</list>
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public Sale()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
