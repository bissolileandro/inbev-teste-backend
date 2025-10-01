using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProduct
{
    /// <summary>
    /// command to get all branchs with pagination
    /// </summary>
    public class GetAllProductCommand : IRequest<GetAllProductPaginedResult>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public GetAllProductCommand()
        {
            
        }

        public GetAllProductCommand(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize < 1 ? 10 : pageSize;
        }

    }
}
