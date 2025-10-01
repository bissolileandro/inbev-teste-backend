using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.ProductsSales.CreateProductSale
{
    /// <summary>
    /// Profile for mapping CreateProductSaleCommand to Customer entity.
    /// </summary>
    public class CreateProductSaleProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductSaleProfile"/> class.
        /// </summary>
        public CreateProductSaleProfile()
        {
            CreateMap<CreateProductSaleCommand, ProductSale>();
            CreateMap<ProductSale, CreateProductSaleResult>();
            CreateMap<Product, CreateProductSaleResult>();
        }

    }
}
