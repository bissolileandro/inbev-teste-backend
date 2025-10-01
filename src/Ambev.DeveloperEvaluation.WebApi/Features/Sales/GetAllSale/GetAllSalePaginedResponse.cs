namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSale
{
    public class GetAllSalePaginedResponse
    {
        public List<GetAllSaleResponse> Items { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
