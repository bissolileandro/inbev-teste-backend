namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    /// <summary>
    /// Request model for GetSale operation
    /// </summary>
    public class GetSaleRequest
    {
        /// <summary>
        /// Identifier of the branch to be retrieved.
        /// </summary>
        public int Id { get; set; }
    }
}
