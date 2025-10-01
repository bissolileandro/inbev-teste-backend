using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.ProductsSales.CreateProductSale;
using Ambev.DeveloperEvaluation.Application.ProductsSales.UpdateProductSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Profile for mapping CreateSaleCommand to Customer entity.
    /// </summary>
    public class CreateSaleProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleProfile"/> class.
        /// </summary>
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>();
            CreateMap<Sale, CreateSaleResult>();
            CreateMap<CreateProductSaleCommand, ProductSale>();
            CreateMap<ProductSale, CreateProductSaleResult>();
            CreateMap<Customer, CreateCustomerResult>();
            CreateMap<Branch, CreateBranchResult>();
            CreateMap<Product, CreateProductResult>();
            
        }

    }
}
