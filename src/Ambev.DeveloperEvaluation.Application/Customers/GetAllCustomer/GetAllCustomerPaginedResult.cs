
namespace Ambev.DeveloperEvaluation.Application.Customers.GetAllCustomer
{
    public class GetAllCustomerPaginedResult
    {
        public List<GetAllCustomerResult> Items { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }        
    }
}
