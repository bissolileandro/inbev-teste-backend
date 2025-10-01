using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    /// <summary>
    /// Validator for DeleteSaleRequest that defines validation rules for branch deletion requests.
    /// </summary>
    public class DeleteSaleRequestValidator : AbstractValidator<DeleteSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the DeleteSaleRequestValidator with defined validation rules.
        /// </summary>
        public DeleteSaleRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
        }
    }
}
