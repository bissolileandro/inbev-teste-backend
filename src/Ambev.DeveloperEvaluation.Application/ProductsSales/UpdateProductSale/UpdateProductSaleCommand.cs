using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.UpdateProductSale
{
    public class UpdateProductSaleCommand : IRequest<UpdateProductSaleResult>
    {
        /// <summary>
        /// Product id.
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
        public int Quantity { get; set; }
        /// <summary>
        /// Unit Price of the product sold.
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// Discount of the product sold.
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// Total of the product sold.
        /// </summary>
        public decimal TotalItem { get; set; }
        /// <summary>
        /// Status of the product sale.
        /// </summary>
        public ProductSaleStatus Status { get; set; }

        /// <summary>
        /// Validates the command using the UpdateProductSaleValidator.
        /// </summary>
        /// <returns></returns>
        public ValidationResultDetail Validate()
        {
            var validator = new UpdateProductSaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }


    }
}
