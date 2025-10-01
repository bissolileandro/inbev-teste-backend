using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch
{
    /// <summary>
    /// Validator for GetBranchCommand that defines validation rules for retrieving a branch by ID.
    /// </summary>
    public class GetBranchValidator : AbstractValidator<GetBranchCommand>
    {
        /// <summary>
        /// Initializes a new instance of the GetBranchValidator with defined validation rules.
        /// </summary>
        public GetBranchValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Branch ID is required")
            .GreaterThan(0).WithMessage("Branch Id must be greater than zero."); ;
        }
    }
}
