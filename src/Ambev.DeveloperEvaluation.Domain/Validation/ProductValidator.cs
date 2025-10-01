using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Description)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Description must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Description cannot be longer than 100 characters.");

            RuleFor(product => product.Price)
                .NotEmpty()
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }
}
