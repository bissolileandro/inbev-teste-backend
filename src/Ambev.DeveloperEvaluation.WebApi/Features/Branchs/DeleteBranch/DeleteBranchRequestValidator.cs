using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.DeleteBranch
{
    /// <summary>
    /// Validator for DeleteBranchRequest that defines validation rules for branch deletion requests.
    /// </summary>
    public class DeleteBranchRequestValidator : AbstractValidator<DeleteBranchRequest>
    {
        /// <summary>
        /// Initializes a new instance of the DeleteBranchRequestValidator with defined validation rules.
        /// </summary>
        public DeleteBranchRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Branch ID is required");
        }
    }
}
