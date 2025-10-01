using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.UpdateProductSale
{
    /// <summary>
    /// UpdateProductSaleValidator is responsible for validating the UpdateProductSaleCommand.
    /// </summary>
    public class UpdateProductSaleValidator : AbstractValidator<UpdateProductSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateProductSaleValidator with defined validation rules.
        /// </summary>
        public UpdateProductSaleValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("ProductSale ID is required")
            .GreaterThan(0).WithMessage("ProductSale Id must be greater than zero."); ;

            RuleFor(ps => ps.ProductId)
                .NotEmpty()
                .WithMessage("ProductId must be provided.")
                .GreaterThan(0).WithMessage("BranchId must be greater than zero."); ;

            RuleFor(ps => ps.SaleId)
                .NotEmpty()
                .WithMessage("SaleId must be provided.")
                .GreaterThan(0).WithMessage("BranchId must be greater than zero."); ;

            RuleFor(ps => ps.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero.");

            RuleFor(ps => ps.UnitPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("UnitPrice must be greater than or equal to zero.");
        }
    }
}
