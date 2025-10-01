
namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProduct
{
    public class GetAllProductPaginedResult
    {
        public List<GetAllProductResult> Items { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }        
    }
}
