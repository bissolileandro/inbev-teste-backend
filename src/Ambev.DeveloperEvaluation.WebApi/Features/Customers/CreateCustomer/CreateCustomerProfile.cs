using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer
{
    /// <summary>
    /// Profile for mapping between CreateCustomerRequest/CreateCustomerResponse and CreateCustomerCommand/CreateCustomerResult
    /// </summary>
    public class CreateCustomerProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateCustomer operation
        /// </summary>
        public CreateCustomerProfile()
        {
            CreateMap<CreateCustomerRequest, CreateCustomerCommand>();
            CreateMap<CreateCustomerResult, CreateCustomerResponse>();
        }
    }
}
