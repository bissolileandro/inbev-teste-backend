namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProduct
{
    public class GetAllProductPaginedResponse
    {
        public List<GetAllProductResponse> Items { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
