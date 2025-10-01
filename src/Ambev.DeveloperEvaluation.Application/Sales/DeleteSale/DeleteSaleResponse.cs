using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Represents the response after deleting a sale.
    /// </summary>
    public class DeleteSaleResponse
    {
        /// <summary>
        /// Indicates whether the product deletion was successful.
        /// </summary>
        public bool Success { get; set; }
    }
}
