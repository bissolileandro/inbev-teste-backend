namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    /// <summary>
    /// Request model for DeleteSale operation
    /// </summary>
    public class DeleteSaleRequest
    {
        /// <summary>
        /// The unique identifier of the branch to delete
        /// </summary>
        public int Id { get; set; }
    }
}
