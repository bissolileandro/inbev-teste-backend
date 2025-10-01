using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch
{
    public class GetBranchResponse
    {
        /// <summary>
        /// Branch id.
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
