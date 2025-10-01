namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetAllCustomer
{
    public class GetAllCustomerPaginedResponse
    {
        public List<GetAllCustomerResponse> Items { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
