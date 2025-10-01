using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.ProductsSales.CreateProductSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleProfile : Profile
    {
        public GetSaleProfile()
        {
            CreateMap<GetSaleCommand, Sale>();
            CreateMap<Sale, GetSaleResult>();
            CreateMap<Customer, CreateCustomerResult>();
            CreateMap<Branch, CreateBranchResult>();
            CreateMap<Product, CreateProductResult>();
            CreateMap<ProductSale, CreateProductSaleResult>();
        }
    }
}
