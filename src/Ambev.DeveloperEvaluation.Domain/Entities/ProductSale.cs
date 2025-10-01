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
    public class ProductSale : BaseEntity<int>
    {
        
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
        /// <summary>
        /// Product reference
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Sale reference
        /// </summary>
        public virtual Sale Sale { get; set; }

        /// <summary>
        /// Cancel product of sale.
        /// Changes the product sale status to Cancel.
        /// </summary>
        public void Cancel()
        {
            Status = ProductSaleStatus.Canceled;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Active product of sale.
        /// Changes the product sale status to Active.
        /// </summary>
        public void Active()
        {
            Status = ProductSaleStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Calculate total item of the product sold.
        /// </summary>
        public void ApplyDiscount(decimal discountPercentual)
        {
            Discount = (Quantity * UnitPrice) * discountPercentual;            
        }

        public void ApplyTotalItem()
        {            
            TotalItem = (Quantity * UnitPrice) - Discount;
        }

        /// <summary>
        /// Performs validation on the current Product Sale entity instance.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>        
        /// <list type="bullet">ProductId must be provided</list>        
        /// <list type="bullet">ProductId must be provided</list>        
        /// <list type="bullet">UnitPrice must be greater than or equal to zero</list>        
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new ProductSaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
        public ProductSale()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
