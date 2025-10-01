using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.UpdateBranch
{
    /// <summary>
    /// Response model for CreateBranch operation
    /// </summary>
    public class UpdateBranchResponse
    {
        /// <summary>
        /// Id of the created branch.
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
    }
}
