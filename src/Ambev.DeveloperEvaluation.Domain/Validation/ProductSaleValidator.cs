using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductSaleValidator : AbstractValidator<ProductSale>
    {
        public ProductSaleValidator()
        {
            RuleFor(ps => ps.ProductId)
                .NotEmpty()
                .WithMessage("ProductId must be provided.");

            RuleFor(ps => ps.SaleId)
                .NotEmpty()
                .WithMessage("SaleId must be provided.");
            
            RuleFor(ps => ps.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero.");
            
            RuleFor(ps => ps.UnitPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("UnitPrice must be greater than or equal to zero.");
            
        }
    }
}
