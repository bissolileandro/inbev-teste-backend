using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch
{
    /// <summary>
    /// Represents the response after deleting a branch.
    /// </summary>
    public class DeleteBranchResponse
    {
        /// <summary>
        /// Indicates whether the branch deletion was successful.
        /// </summary>
        public bool Success { get; set; }
    }
}
