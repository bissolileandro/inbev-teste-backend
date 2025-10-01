using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch
{
    public class UpdateBranchCommand : IRequest<UpdateBranchResult>
    {
        /// <summary>
        /// Id of the branch to be updated.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Branch's name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets the branch's email address.        
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets the branch's phone number.        
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Gets the branch status.        
        /// </summary>
        public BranchStatus Status { get; set; }

        /// <summary>
        /// Validates the command using the UpdateBranchValidator.
        /// </summary>
        /// <returns></returns>
        public ValidationResultDetail Validate()
        {
            var validator = new UpdateBranchValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }


    }
}
