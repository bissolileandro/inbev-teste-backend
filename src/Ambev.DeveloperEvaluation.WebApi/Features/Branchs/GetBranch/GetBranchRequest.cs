namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch
{
    /// <summary>
    /// Request model for GetBranch operation
    /// </summary>
    public class GetBranchRequest
    {
        /// <summary>
        /// Identifier of the branch to be retrieved.
        /// </summary>
        public int Id { get; set; }
    }
}
