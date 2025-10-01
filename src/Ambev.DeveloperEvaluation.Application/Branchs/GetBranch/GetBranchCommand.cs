using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch
{
    /// <summary>
    /// Command to get a branch by Id.
    /// </summary>
    public class GetBranchCommand : IRequest<GetBranchResult>
    {
        /// <summary>
        /// Get or set the Id of the branch to be retrieved.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the branch's name.
        /// </summary>
        /// <param name="id"></param>
        public GetBranchCommand(int id)
        {
            Id = id;
        }
    }
}
