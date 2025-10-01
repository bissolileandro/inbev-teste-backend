using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    /// <summary>
    /// Profile for mapping CreateProductCommand to Customer entity.
    /// </summary>
    public class CreateProductProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductProfile"/> class.
        /// </summary>
        public CreateProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, CreateProductResult>();
        }

    }
}
