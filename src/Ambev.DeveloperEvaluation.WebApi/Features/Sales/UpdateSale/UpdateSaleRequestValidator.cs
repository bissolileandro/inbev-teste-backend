using Ambev.DeveloperEvaluation.Application.ProductsSales.UpdateProductSale;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// Validator for CreateCustomerCommand that defines validation rules for Customer creation command.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)    
    /// - Phone: Must match international (using Phonevalidator)    
    /// - Name: Cannot be set to None
    /// </remarks>
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateCustomerValidator with defined validation rules.
        /// </summary>
        public UpdateSaleRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("ProductSale ID is required")
            .GreaterThan(0).WithMessage("ProductSale Id must be greater than zero."); ;

            RuleFor(sale => sale.SaleDate)
                .NotEmpty().WithMessage("Sale date cannot be empty.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Sale date cannot be in the future.");

            RuleFor(sale => sale.BranchId)
                .GreaterThan(0).WithMessage("BranchId must be greater than zero.");

            RuleFor(sale => sale.CustomerId)
                .GreaterThan(0).WithMessage("CustomerId must be greater than zero.");

            RuleForEach(sale => sale.ProductsSales)
                .SetValidator(new UpdateProductSaleValidator())
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
