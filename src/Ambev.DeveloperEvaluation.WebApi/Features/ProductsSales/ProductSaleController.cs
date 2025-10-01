using Ambev.DeveloperEvaluation.Application.ProductsSales.DeleteProductSale;
using Ambev.DeveloperEvaluation.Application.ProductsSales.GetProductSale;
using Ambev.DeveloperEvaluation.Application.ProductsSales.UpdateProductSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.ProductsSales.DeleteProductSale;
using Ambev.DeveloperEvaluation.WebApi.Features.ProductsSales.GetProductSale;
using Ambev.DeveloperEvaluation.WebApi.Features.ProductsSales.UpdateProductSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsSales
{
    /// <summary>
    /// Controller for managing GetProductSaleSale sale-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSaleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSaleController"/> class.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        public ProductSaleController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Deletes a product sale by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProductSale([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new DeleteProductSaleRequest { Id = id };
            var validator = new DeleteProductSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteProductSaleCommand>(request.Id);
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "GetProductSaleSale deleted successfully"
            });
        }

        /// <summary>
        /// Gets a product sale by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetProductSaleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductSale([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new GetProductSaleRequest { Id = id };
            var validator = new GetProductSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetProductSaleCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetProductSaleResponse>
            {
                Success = true,
                Message = "Product retrieved successfully",
                Data = _mapper.Map<GetProductSaleResponse>(response)
            });
        }

        /// <summary>
        /// Updates an existing product sale.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateProductSaleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProductSale([FromBody] UpdateProductSaleRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateProductSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<UpdateProductSaleResponse>
            {
                Success = true,
                Message = "ProductSale updated successfully",
                Data = _mapper.Map<UpdateProductSaleResponse>(response)
            });
        }
    }
}
