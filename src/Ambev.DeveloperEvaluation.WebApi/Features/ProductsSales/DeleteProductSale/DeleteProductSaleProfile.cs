using Ambev.DeveloperEvaluation.Application.ProductsSales.DeleteProductSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsSales.DeleteProductSale
{
    public class DeleteProductSaleProfile : Profile
    {
        public DeleteProductSaleProfile()
        {
            CreateMap<int, DeleteProductSaleCommand>()
                .ConstructUsing(id => new DeleteProductSaleCommand(id));
        }
    }
}
