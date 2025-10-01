using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch
{
    /// <summary>
    /// Handler for processing DeleteBranchCommand requests
    /// </summary>
    public class DeleteBranchHandler : IRequestHandler<DeleteBranchCommand, DeleteBranchResponse>
    {
        private readonly IBranchRepository _branchRepository;

        /// <summary>
        /// Initializes a new instance of DeleteBranchHandler
        /// </summary>
        /// <param name="branchRepository"></param>
        public DeleteBranchHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        /// <summary>
        /// Handles the DeleteBranchCommand request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The result of the delete operation</returns>        
        public async Task<DeleteBranchResponse> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteBranchValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _branchRepository.DeleteAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Branch with ID {request.Id} not found");

            return new DeleteBranchResponse { Success = true };
        }
    }
}
