namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.DeleteBranch
{
    /// <summary>
    /// Request model for DeleteBranch operation
    /// </summary>
    public class DeleteBranchRequest
    {
        /// <summary>
        /// The unique identifier of the branch to delete
        /// </summary>
        public int Id { get; set; }
    }
}
