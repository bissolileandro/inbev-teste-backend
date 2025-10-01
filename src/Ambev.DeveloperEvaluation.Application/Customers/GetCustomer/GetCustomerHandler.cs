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

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerCommand, GetCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<GetCustomerResult> Handle(GetCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetCustomerValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var branch = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);
            if (branch == null)
                throw new KeyNotFoundException($"Branch with ID {request.Id} not found");

            return _mapper.Map<GetCustomerResult>(branch);
        }
    }
}
