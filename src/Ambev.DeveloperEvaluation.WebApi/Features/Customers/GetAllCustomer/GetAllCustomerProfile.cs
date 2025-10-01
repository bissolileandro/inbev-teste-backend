using Ambev.DeveloperEvaluation.Application.Customers.GetAllCustomer;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetAllCustomer
{
    public class GetAllCustomerProfile : Profile
    {
        public GetAllCustomerProfile()
        {
            CreateMap<Customer, GetAllCustomerResult>();            
            CreateMap<GetAllCustomerResult, GetAllCustomerResponse>();
            CreateMap<Customer, GetAllCustomerResponse>();
            CreateMap<GetAllCustomerRequest, GetAllCustomerCommand>();
            CreateMap<GetAllCustomerPaginedResult, GetAllCustomerPaginedResponse>();
        }
    }
}
