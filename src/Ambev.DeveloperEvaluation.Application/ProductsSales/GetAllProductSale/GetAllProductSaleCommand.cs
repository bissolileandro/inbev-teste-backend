using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.GetAllProductSale
{
    /// <summary>
    /// command to get all branchs with pagination
    /// </summary>
    public class GetAllProductSaleCommand : IRequest<GetAllProductSalePaginedResult>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public GetAllProductSaleCommand()
        {
            
        }

        public GetAllProductSaleCommand(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize < 1 ? 10 : pageSize;
        }

    }
}
