using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.GetProductSale
{
    /// <summary>
    /// Validator for GetProductSaleCommand that defines validation rules for retrieving a product by ID.
    /// </summary>
    public class GetProductSaleValidator : AbstractValidator<GetProductSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the GetProductSaleValidator with defined validation rules.
        /// </summary>
        public GetProductSaleValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product Sale ID is required");
        }
    }
}
