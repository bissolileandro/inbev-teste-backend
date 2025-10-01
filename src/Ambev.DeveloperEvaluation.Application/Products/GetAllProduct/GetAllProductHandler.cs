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

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProduct
{
    /// <summary>
    /// Handler for getting all customers with pagination
    /// </summary>
    public class GetAllProductHandler : IRequestHandler<GetAllProductCommand, GetAllProductPaginedResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetAllProductPaginedResult> Handle(GetAllProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetAllProductValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var listProduct = _mapper.Map<List<GetAllProductResult>>(await _productRepository.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken));
            if (listProduct == null)
                throw new KeyNotFoundException($"products not found");

            return new GetAllProductPaginedResult
            {
                Items = listProduct,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize                
            };
        }
    }
}
