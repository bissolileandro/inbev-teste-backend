using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetAllBranchs
{
    /// <summary>
    /// Validator for GetAllBranchCommand
    /// </summary>
    public class GetAllBranchValidator : AbstractValidator<GetAllBranchCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetAllBranchCommand
        /// </summary>
        public GetAllBranchValidator()
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
