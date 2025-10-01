namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.DeleteCustomer
{
    /// <summary>
    /// Request model for DeleteCustomer operation
    /// </summary>
    public class DeleteCustomerRequest
    {
        /// <summary>
        /// The unique identifier of the branch to delete
        /// </summary>
        public int Id { get; set; }
    }
}
