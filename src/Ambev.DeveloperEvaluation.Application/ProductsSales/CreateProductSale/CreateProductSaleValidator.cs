using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.CreateProductSale
{
    /// <summary>
    /// Validator for CreateProductSaleCommand that defines validation rules for product creation command.
    /// </summary>    
    public class CreateProductSaleValidator : AbstractValidator<CreateProductSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateProductSaleValidator with defined validation rules.
        /// </summary>
        public CreateProductSaleValidator()
        {
            RuleFor(ps => ps.ProductId)
                .NotEmpty()
                .WithMessage("ProductId must be provided.");

            //RuleFor(ps => ps.SaleId)
            //    .NotEmpty()
            //    .WithMessage("SaleId must be provided.");

            RuleFor(ps => ps.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero.");

            RuleFor(ps => ps.UnitPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("UnitPrice must be greater than or equal to zero.");


        }
    }
}
