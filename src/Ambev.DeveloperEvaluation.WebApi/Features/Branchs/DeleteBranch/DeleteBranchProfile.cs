using Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.DeleteBranch
{
    public class DeleteBranchProfile : Profile
    {
        public DeleteBranchProfile()
        {
            CreateMap<int, DeleteBranchCommand>()
                .ConstructUsing(id => new DeleteBranchCommand(id));
        }
    }
}
