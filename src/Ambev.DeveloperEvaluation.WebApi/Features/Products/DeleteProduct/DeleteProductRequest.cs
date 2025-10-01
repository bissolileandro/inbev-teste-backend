namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct
{
    /// <summary>
    /// Request model for DeleteProduct operation
    /// </summary>
    public class DeleteProductRequest
    {
        /// <summary>
        /// The unique identifier of the branch to delete
        /// </summary>
        public int Id { get; set; }
    }
}
