using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductResult>
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
        public decimal Price { get; set; } = 0;

        /// <summary>
        /// Gets the Product status.        
        /// </summary>
        public ProductStatus Status { get; set; }

        /// <summary>
        /// Validates the command using the UpdateProductValidator.
        /// </summary>
        /// <returns></returns>
        public ValidationResultDetail Validate()
        {
            var validator = new UpdateProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }


    }
}
