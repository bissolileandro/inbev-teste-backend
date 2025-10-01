using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetAllBranch
{
    /// <summary>
    /// Validator for GetAllBranchRequest
    /// </summary>
    public class GetAllBranchRequestValidator : AbstractValidator<GetAllBranchRequest>
    {
        /// <summary>
        /// Initializes validation rules for GetAllBranchRequest
        /// </summary>
        public GetAllBranchRequestValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("The page number must be greater than zero.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("Page size must be greater than zero.");
        }
    }
}
