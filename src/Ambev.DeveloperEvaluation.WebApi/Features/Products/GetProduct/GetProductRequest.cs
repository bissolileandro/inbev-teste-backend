namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{
    /// <summary>
    /// Request model for GetProduct operation
    /// </summary>
    public class GetProductRequest
    {
        /// <summary>
        /// Identifier of the branch to be retrieved.
        /// </summary>
        public int Id { get; set; }
    }
}
