using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch
{
    /// <summary>
    /// Profile for mapping CreateBranchCommand to Branch entity.
    /// </summary>
    public class CreateBranchProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBranchProfile"/> class.
        /// </summary>
        public CreateBranchProfile()
        {
            CreateMap<CreateBranchCommand, Branch>();
            CreateMap<Branch, CreateBranchResult>();
        }

    }
}
