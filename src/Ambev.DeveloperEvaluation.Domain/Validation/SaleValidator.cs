using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.SaleDate)
                .NotEmpty().WithMessage("Sale date cannot be empty.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Sale date cannot be in the future.");

            RuleFor(sale => sale.BranchId)
                .GreaterThan(0).WithMessage("BranchId must be greater than zero.");

            RuleFor(sale => sale.CustomerId)
                .GreaterThan(0).WithMessage("CustomerId must be greater than zero.");

            RuleForEach(sale => sale.ProductsSales)
                .SetValidator(new ProductSaleValidator())
                .When(sale => sale.ProductsSales != null && sale.ProductsSales.Any())
                .WithMessage("Each product sale must be valid.");

        }
    }
}
