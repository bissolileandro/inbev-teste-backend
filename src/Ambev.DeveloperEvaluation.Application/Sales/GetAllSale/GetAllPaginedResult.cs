
namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSale
{
    public class GetAllSalePaginedResult
    {
        public List<GetAllSaleResult> Items { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }        
    }
}
