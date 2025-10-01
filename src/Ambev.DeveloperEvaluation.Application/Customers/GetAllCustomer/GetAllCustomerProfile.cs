using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetAllCustomer
{
    /// <summary>
    /// Profile for mapping Customer to GetAllCustomerResult
    /// </summary>
    public class GetAllCustomerProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllCustomerProfile"/> class.
        /// </summary>
        public GetAllCustomerProfile()
        {
            CreateMap<Customer, GetAllCustomerResult>();            
        }
    }
}
