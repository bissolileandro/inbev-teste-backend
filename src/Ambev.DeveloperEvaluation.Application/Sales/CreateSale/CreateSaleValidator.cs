using Ambev.DeveloperEvaluation.Application.ProductsSales.CreateProductSale;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Validator for CreateSaleCommand that defines validation rules for product creation command.
    /// </summary>    
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleValidator with defined validation rules.
        /// </summary>
        public CreateSaleValidator()
        {
            RuleFor(sale => sale.SaleDate)
                .NotEmpty().WithMessage("Sale date cannot be empty.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Sale date cannot be in the future.");

            RuleFor(sale => sale.BranchId)
                .GreaterThan(0).WithMessage("BranchId must be greater than zero.");

            RuleFor(sale => sale.CustomerId)
                .GreaterThan(0).WithMessage("CustomerId must be greater than zero.");

            RuleForEach(sale => sale.ProductsSales)
                .SetValidator(new CreateProductSaleValidator())
                .When(sale => sale.ProductsSales != null && sale.ProductsSales.Any())
                .WithMessage("Each product sale must be valid.");

            RuleFor(sale => sale.ProductsSales)
                .Custom((listProductSale, context) =>
                {
                    if (listProductSale == null) return;

                    var productsGreater20 = listProductSale
                        .GroupBy(i => i.ProductId)
                        .Where(g => g.Sum(i => i.Quantity) > 20)
                        .ToList();

                    foreach (var product in productsGreater20)
                    {
                        context.AddFailure($"Product {product.Key} has exceeded the 20 unit limit.");
                    }
                });
        }
    }
}
