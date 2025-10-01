using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch
{
    /// <summary>
    /// Validator for GetBranchRequest that defines validation rules for branch retrieval requests.
    /// </summary>
    public class GetBranchRequestValidator : AbstractValidator<GetBranchRequest>
    {
        /// <summary>
        /// Initializes a new instance of the GetBranchRequestValidator with defined validation rules.
        /// </summary>
        public GetBranchRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Branch ID is required");
        }
    }
}
