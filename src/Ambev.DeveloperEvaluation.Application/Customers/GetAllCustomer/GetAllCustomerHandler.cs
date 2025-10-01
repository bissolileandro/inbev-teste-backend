using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetAllCustomer
{
    /// <summary>
    /// Handler for getting all customers with pagination
    /// </summary>
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerCommand, GetAllCustomerPaginedResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetAllCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<GetAllCustomerPaginedResult> Handle(GetAllCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetAllCustomerValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var listCustomer = _mapper.Map<List<GetAllCustomerResult>>(await _customerRepository.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken));
            if (listCustomer == null)
                throw new KeyNotFoundException($"customers not found");

            return new GetAllCustomerPaginedResult
            {
                Items = listCustomer,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize                
            };
        }
    }
}
