using Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProduct
{
    public class GetAllProductProfile : Profile
    {
        public GetAllProductProfile()
        {
            CreateMap<Product, GetAllProductResult>();            
            CreateMap<GetAllProductResult, GetAllProductResponse>();
            CreateMap<Product, GetAllProductResponse>();
            CreateMap<GetAllProductRequest, GetAllProductCommand>();
            CreateMap<GetAllProductPaginedResult, GetAllProductPaginedResponse>();
        }
    }
}
