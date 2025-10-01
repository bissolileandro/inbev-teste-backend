using Ambev.DeveloperEvaluation.Application.ProductsSales.UpdateProductSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsSales.UpdateProductSale
{
    /// <summary>
    /// Profile for mapping between CreateBranchRequest/CreateBranchResponse and CreateBranchCommand/CreateBranchResult
    /// </summary>
    public class UpdateProductSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateBranch operation
        /// </summary>
        public UpdateProductSaleProfile()
        {
            CreateMap<UpdateProductSaleRequest, UpdateProductSaleCommand>();
            CreateMap<UpdateProductSaleResult, UpdateProductSaleResponse>();
        }
    }
}
