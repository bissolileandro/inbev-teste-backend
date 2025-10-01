using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch
{
    /// <summary>
    /// UpdateBranchValidator is responsible for validating the UpdateBranchCommand.
    /// </summary>
    public class UpdateBranchValidator : AbstractValidator<UpdateBranchCommand>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateBranchValidator with defined validation rules.
        /// </summary>
        public UpdateBranchValidator()
        {
            RuleFor(branch => branch.Id)
                .NotEmpty().WithMessage("Branch ID cannot be empty.")
                .GreaterThan(0).WithMessage("Branch ID must be greater than zero.");    

            RuleFor(branch => branch.Email).SetValidator(new EmailValidator());

            RuleFor(branch => branch.Phone).SetValidator(new PhoneValidator());

            RuleFor(branch => branch.Name)
                .NotEmpty().WithMessage("Branch name cannot be empty.")
                .MinimumLength(3).WithMessage("Branch name must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Branch name cannot be longer than 100 characters.");
        }
    }
}
