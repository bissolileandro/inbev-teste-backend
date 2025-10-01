using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.ProductsSales.CreateProductSale;
using Ambev.DeveloperEvaluation.Application.ProductsSales.GetAllProductSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSale
{
    /// <summary>
    /// Profile for mapping Product to GetAllSaleResult
    /// </summary>
    public class GetAllSaleProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSaleProfile"/> class.
        /// </summary>
        public GetAllSaleProfile()
        {
            CreateMap<GetAllSaleCommand, Sale>();
            CreateMap<Sale, GetAllSaleResult>();            
            CreateMap<ProductSale, CreateProductSaleResult>();
            CreateMap<Customer, CreateCustomerResult>();
            CreateMap<Branch, CreateBranchResult>();
            CreateMap<Product, CreateProductResult>();
        }
    }
}
