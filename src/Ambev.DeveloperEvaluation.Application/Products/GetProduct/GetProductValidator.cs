using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    /// <summary>
    /// Validator for GetProductCommand that defines validation rules for retrieving a product by ID.
    /// </summary>
    public class GetProductValidator : AbstractValidator<GetProductCommand>
    {
        /// <summary>
        /// Initializes a new instance of the GetProductValidator with defined validation rules.
        /// </summary>
        public GetProductValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required")
            .GreaterThan(0).WithMessage("Product Id must be greater than zero."); 
        }
    }
}
