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

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSale
{
    /// <summary>
    /// Handler for getting all customers with pagination
    /// </summary>
    public class GetAllSaleHandler : IRequestHandler<GetAllSaleCommand, GetAllSalePaginedResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        public GetAllSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }
        public async Task<GetAllSalePaginedResult> Handle(GetAllSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetAllSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var listProductSale = _mapper.Map<List<GetAllSaleResult>>(await _saleRepository.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken));
            if (listProductSale == null)
                throw new KeyNotFoundException($"sale not found");

            return new GetAllSalePaginedResult
            {
                Items = listProductSale,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize                
            };
        }
    }
}
