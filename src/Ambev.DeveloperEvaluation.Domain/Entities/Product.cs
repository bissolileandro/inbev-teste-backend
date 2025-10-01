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
    public class Product : BaseEntity<int>
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
        /// Gets or sets the collection of product sales associated with this entity.
        /// </summary>
        public virtual List<ProductSale>? ProductsSales { get; set; }

        /// <summary>
        /// Gets or sets the current status of the product.
        /// </summary>
        public ProductStatus Status { get; set; }

        /// <summary>
        /// Deactivates the product.
        /// Changes the product's status to Inactive.
        /// </summary>
        public void Deactivate()
        {
            Status = ProductStatus.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Active product.
        /// Changes the product status to Active.
        /// </summary>
        public void Active()
        {
            Status = ProductStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Performs validation on the current Product entity instance.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>        
        /// <list type="bullet">Price empty or greater 0 </list>        
        /// <list type="bullet">Description Empty or Minimum and Maximoum Length</list>        
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public Product()
        {
            CreatedAt = DateTime.UtcNow;
        }

    }
}
