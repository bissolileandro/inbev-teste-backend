using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsSales.UpdateProductSale
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
    public class UpdateProductSaleRequestValidator : AbstractValidator<UpdateProductSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateCustomerValidator with defined validation rules.
        /// </summary>
        public UpdateProductSaleRequestValidator()
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
