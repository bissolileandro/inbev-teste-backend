using Ambev.DeveloperEvaluation.Application.Sales.GetAllSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSale
{
    public class GetAllSaleProfile : Profile
    {
        public GetAllSaleProfile()
        {
            CreateMap<Product, GetAllSaleResult>();            
            CreateMap<GetAllSaleResult, GetAllSaleResponse>();
            CreateMap<Product, GetAllSaleResponse>();
            CreateMap<GetAllSaleRequest, GetAllSaleCommand>();
            CreateMap<GetAllSalePaginedResult, GetAllSalePaginedResponse>();
        }
    }
}
