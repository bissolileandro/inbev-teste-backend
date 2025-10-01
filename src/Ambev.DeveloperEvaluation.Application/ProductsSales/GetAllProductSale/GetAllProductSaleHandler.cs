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

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.GetAllProductSale
{
    /// <summary>
    /// Handler for getting all customers with pagination
    /// </summary>
    public class GetAllProductSaleHandler : IRequestHandler<GetAllProductSaleCommand, GetAllProductSalePaginedResult>
    {
        private readonly IProductSaleRepository _productSaleRepository;
        private readonly IMapper _mapper;
        public GetAllProductSaleHandler(IProductSaleRepository productSaleRepository, IMapper mapper)
        {
            _productSaleRepository = productSaleRepository;
            _mapper = mapper;
        }
        public async Task<GetAllProductSalePaginedResult> Handle(GetAllProductSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetAllProductSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var listProductSale = _mapper.Map<List<GetAllProductSaleResult>>(await _productSaleRepository.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken));
            if (listProductSale == null)
                throw new KeyNotFoundException($"products sale not found");

            return new GetAllProductSalePaginedResult
            {
                Items = listProductSale,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize                
            };
        }
    }
}
