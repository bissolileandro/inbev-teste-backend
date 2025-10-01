using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class BranchValidator : AbstractValidator<Branch>
    {
        public BranchValidator()
        {
            RuleFor(branch => branch.Email).SetValidator(new EmailValidator());

            RuleFor(branch => branch.Phone).SetValidator(new PhoneValidator());

            RuleFor(branch => branch.Name)
                .NotEmpty().WithMessage("Branch name cannot be empty.")
                .MinimumLength(3).WithMessage("Branch name must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Branch name cannot be longer than 100 characters.");
        }
    }
}
