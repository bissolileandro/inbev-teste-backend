
namespace Ambev.DeveloperEvaluation.Application.ProductsSales.GetAllProductSale
{
    public class GetAllProductSalePaginedResult
    {
        public List<GetAllProductSaleResult> Items { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }        
    }
}
