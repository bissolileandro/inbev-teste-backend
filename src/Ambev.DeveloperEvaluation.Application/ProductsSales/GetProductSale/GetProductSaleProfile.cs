using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.GetProductSale
{
    public class GetProductSaleProfile : Profile
    {
        public GetProductSaleProfile()
        {
            CreateMap<ProductSale, GetProductSaleResult>();
        }
    }
}
