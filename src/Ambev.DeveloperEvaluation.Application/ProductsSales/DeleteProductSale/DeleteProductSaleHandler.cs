using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.DeleteProductSale
{
    /// <summary>
    /// Handler for processing DeleteProductSaleCommand requests
    /// </summary>
    public class DeleteProductSaleHandler : IRequestHandler<DeleteProductSaleCommand, DeleteProductSaleResponse>
    {
        private readonly IProductSaleRepository _productSaleRepository;

        /// <summary>
        /// Initializes a new instance of DeleteProductSaleHandler
        /// </summary>
        /// <param name="branchRepository"></param>
        public DeleteProductSaleHandler(IProductSaleRepository productSaleRepository)
        {
            _productSaleRepository = productSaleRepository;
        }

        /// <summary>
        /// Handles the DeleteProductSaleCommand request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The result of the delete operation</returns>        
        public async Task<DeleteProductSaleResponse> Handle(DeleteProductSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteProductSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _productSaleRepository.DeleteAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found");

            return new DeleteProductSaleResponse { Success = true };
        }
    }
}
