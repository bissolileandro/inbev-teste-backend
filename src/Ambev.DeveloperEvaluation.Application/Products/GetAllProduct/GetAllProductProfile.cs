using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProduct
{
    /// <summary>
    /// Profile for mapping Product to GetAllProductResult
    /// </summary>
    public class GetAllProductProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllProductProfile"/> class.
        /// </summary>
        public GetAllProductProfile()
        {
            CreateMap<Product, GetAllProductResult>();            
        }
    }
}
