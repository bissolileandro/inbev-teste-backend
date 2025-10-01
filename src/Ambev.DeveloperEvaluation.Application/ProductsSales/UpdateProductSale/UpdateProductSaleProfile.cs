using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.UpdateProductSale
{
    public class UpdateProductSaleProfile : Profile
    {
        public UpdateProductSaleProfile()
        {
            CreateMap<UpdateProductSaleCommand, ProductSale>();
            CreateMap<ProductSale, UpdateProductSaleResult>();    
        }
    }
}
