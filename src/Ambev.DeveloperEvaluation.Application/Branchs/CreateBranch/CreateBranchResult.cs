using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch
{
    public class CreateBranchResult
    {
        /// <summary>
        /// Branch id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Branch's name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
