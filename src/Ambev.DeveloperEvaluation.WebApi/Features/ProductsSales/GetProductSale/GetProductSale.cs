using Ambev.DeveloperEvaluation.Application.ProductsSales.GetProductSale;
using Ambev.DeveloperEvaluation.WebApi.Features.ProductsSales.GetProductSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductSale
{
    public class GetProductSaleProfile : Profile
    {
        public GetProductSaleProfile()
        {
            CreateMap<int, GetProductSaleCommand>()
                .ConstructUsing(id => new GetProductSaleCommand(id));

            CreateMap<GetProductSaleResult, GetProductSaleResponse>();
        }
    }
}
