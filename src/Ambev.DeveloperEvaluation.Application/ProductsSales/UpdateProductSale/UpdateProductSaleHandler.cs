using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.UpdateProductSale
{
    public class UpdateProductSaleHandler : IRequestHandler<UpdateProductSaleCommand, UpdateProductSaleResult>
    {
        private readonly IProductSaleRepository _productSaleRepository;
        private readonly IMapper _mapper;
        public UpdateProductSaleHandler(IProductSaleRepository productSaleRepository, IMapper mapper)
        {
            _productSaleRepository = productSaleRepository;
            _mapper = mapper;
        }
        public async Task<UpdateProductSaleResult> Handle(UpdateProductSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var productSale = _mapper.Map<ProductSale>(command);            
            productSale.ApplyTotalItem();

            var updateProductSale = await _productSaleRepository.UpdateAsync(productSale, cancellationToken);
            var result = _mapper.Map<UpdateProductSaleResult>(updateProductSale);
            return result;
        }
    }
}
