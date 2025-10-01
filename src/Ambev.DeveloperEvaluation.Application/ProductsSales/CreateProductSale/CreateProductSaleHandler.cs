using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ProductsSales.CreateProductSale
{
    /// <summary>
    /// Handler for processing CreateBranchCommand requests.
    /// </summary>
    public class CreateProductSaleHandler : IRequestHandler<CreateProductSaleCommand, CreateProductSaleResult>
    {
        private readonly IProductSaleRepository _productSaleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateProductSaleHandler.
        /// </summary>
        /// <param name="branchRepository"></param>
        /// <param name="mapper"></param>
        public CreateProductSaleHandler(IProductSaleRepository productSaleRepository, IMapper mapper)
        {
            _productSaleRepository = productSaleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateProductSaleCommand request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<CreateProductSaleResult> Handle(CreateProductSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateProductSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);            

            var product = _mapper.Map<ProductSale>(command);            

            var createdProductSale = await _productSaleRepository.CreateAsync(product, cancellationToken);
            var result = _mapper.Map<CreateProductSaleResult>(createdProductSale);
            return result;
        }
    }
}
