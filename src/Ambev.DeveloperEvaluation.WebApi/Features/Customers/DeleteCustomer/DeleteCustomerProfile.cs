
using Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.DeleteCustomer
{
    public class DeleteCustomerProfile : Profile
    {
        public DeleteCustomerProfile()
        {
            CreateMap<int, DeleteCustomerCommand>()
                .ConstructUsing(id => new DeleteCustomerCommand(id));
        }
    }
}
