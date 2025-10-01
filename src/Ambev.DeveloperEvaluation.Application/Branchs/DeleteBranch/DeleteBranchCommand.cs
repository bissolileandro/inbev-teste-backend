using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch
{
    public class DeleteBranchCommand : IRequest<DeleteBranchResponse>
    {
        /// <summary>
        /// Identifier of the branch to be deleted.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteBranchCommand"/> class.
        /// </summary>
        /// <param name="id"></param>
        public DeleteBranchCommand(int id)
        {
            Id = id;
        }
    }
}
