using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Validator for GetSaleCommand that defines validation rules for retrieving a product by ID.
    /// </summary>
    public class GetSaleValidator : AbstractValidator<GetSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the GetSaleValidator with defined validation rules.
        /// </summary>
        public GetSaleValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
        }
    }
}
