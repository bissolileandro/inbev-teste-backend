using Ambev.DeveloperEvaluation.Application.Branchs.GetAllBranchs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetAllBranch
{
    public class GetAllBranchPaginedResponse
    {
        public List<GetAllBranchResponse> Items { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
