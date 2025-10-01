using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer
{
    /// <summary>
    /// Handler for processing DeleteCustomerCommand requests
    /// </summary>
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of DeleteCustomerHandler
        /// </summary>
        /// <param name="branchRepository"></param>
        public DeleteCustomerHandler(ICustomerRepository branchRepository)
        {
            _customerRepository = branchRepository;
        }

        /// <summary>
        /// Handles the DeleteCustomerCommand request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The result of the delete operation</returns>        
        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCustomerValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _customerRepository.DeleteAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Customer with ID {request.Id} not found");

            return new DeleteCustomerResponse { Success = true };
        }
    }
}
