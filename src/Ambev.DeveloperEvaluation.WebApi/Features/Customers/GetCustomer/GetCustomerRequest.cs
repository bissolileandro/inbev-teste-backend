namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer
{
    /// <summary>
    /// Request model for GetCustomer operation
    /// </summary>
    public class GetCustomerRequest
    {
        /// <summary>
        /// Identifier of the branch to be retrieved.
        /// </summary>
        public int Id { get; set; }
    }
}
