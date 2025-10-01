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

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.GetProductSale
{
    public class GetProductSaleHandler : IRequestHandler<GetProductSaleCommand, GetProductSaleResult>
    {
        private readonly IProductSaleRepository _productSaleRepository;
        private readonly IMapper _mapper;
        public GetProductSaleHandler(IProductSaleRepository productSaleRepository, IMapper mapper)
        {
            _productSaleRepository = productSaleRepository;
            _mapper = mapper;
        }
        public async Task<GetProductSaleResult> Handle(GetProductSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetProductSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var productSale = await _productSaleRepository.GetByIdAsync(request.Id, cancellationToken);
            if (productSale == null)
                throw new KeyNotFoundException($"ProductSale with ID {request.Id} not found");

            return _mapper.Map<GetProductSaleResult>(productSale);
        }
    }
}
