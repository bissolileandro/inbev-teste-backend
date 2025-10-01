using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.GetAllProductSale
{
    /// <summary>
    /// Profile for mapping Product to GetAllProductSaleResult
    /// </summary>
    public class GetAllProductSaleProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllProductSaleProfile"/> class.
        /// </summary>
        public GetAllProductSaleProfile()
        {
            CreateMap<ProductSale, GetAllProductSaleResult>();            
        }
    }
}
