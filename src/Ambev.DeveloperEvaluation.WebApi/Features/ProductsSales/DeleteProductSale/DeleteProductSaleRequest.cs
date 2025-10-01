namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsSales.DeleteProductSale
{
    /// <summary>
    /// Request model for DeleteProductSale operation
    /// </summary>
    public class DeleteProductSaleRequest
    {
        /// <summary>
        /// The unique identifier of the branch to delete
        /// </summary>
        public int Id { get; set; }
    }
}
