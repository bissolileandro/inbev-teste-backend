using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch
{
    /// <summary>
    /// Validator for CreateBranchCommand that defines validation rules for branch creation command.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)    
    /// - Phone: Must match international (using Phonevalidator)    
    /// - Name: Cannot be set to None
    /// </remarks>
    public class CreateBranchRequestValidator : AbstractValidator<CreateBranchRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateBranchValidator with defined validation rules.
        /// </summary>
        public CreateBranchRequestValidator()
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
