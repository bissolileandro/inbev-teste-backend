using Ambev.DeveloperEvaluation.Application.Branchs.GetAllBranchs;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetAllBranch
{
    public class GetAllBranchProfile : Profile
    {
        public GetAllBranchProfile()
        {
            CreateMap<Branch, GetAllBranchResult>();            
            CreateMap<GetAllBranchResult, GetAllBranchResponse>();
            CreateMap<Branch, GetAllBranchResponse>();
            CreateMap<GetAllBranchRequest, GetAllBranchCommand>();
            CreateMap<GetAllBranchPaginedResult, GetAllBranchPaginedResponse>();
        }
    }
}
