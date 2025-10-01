using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetAllBranchs
{
    /// <summary>
    /// Profile for mapping Branch to GetAllBranchResult
    /// </summary>
    public class GetAllBranchProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllBranchProfile"/> class.
        /// </summary>
        public GetAllBranchProfile()
        {
            CreateMap<Branch, GetAllBranchResult>();            
        }
    }
}
