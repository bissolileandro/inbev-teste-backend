using Ambev.DeveloperEvaluation.Application.ProductsSales.CreateProductSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateProductSaleHandlerTests
    {
        private readonly IProductSaleRepository _productSaleRepository;
        private readonly IMapper _mapper;
        private readonly CreateProductSaleHandler _handler;

        public CreateProductSaleHandlerTests()
        {
            _productSaleRepository = Substitute.For<IProductSaleRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateProductSaleHandler(_productSaleRepository, _mapper);
        }

        [Fact(DisplayName = "Given valid product sale data When creating product sale Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = CreateProductSaleHandlerTestData.GenerateValidCommand();
            var productSale = new ProductSale
            {
                Id = 1,
                ProductId = command.ProductId,
                SaleId = command.SaleId,
                Quantity = command.Quantity,
                UnitPrice = command.UnitPrice,
                Discount = command.Discount,
                TotalItem = command.TotalItem,
                Status = command.Status
            };

            var result = new CreateProductSaleResult
            {
                Id = productSale.Id
            };

            _mapper.Map<ProductSale>(command).Returns(productSale);
            _mapper.Map<CreateProductSaleResult>(productSale).Returns(result);

            _productSaleRepository.CreateAsync(Arg.Any<ProductSale>(), Arg.Any<CancellationToken>())
                .Returns(productSale);

            // When
            var createProductSaleResult = await _handler.Handle(command, CancellationToken.None);

            // Then
            createProductSaleResult.Should().NotBeNull();
            createProductSaleResult.Id.Should().Be(productSale.Id);
            await _productSaleRepository.Received(1).CreateAsync(Arg.Any<ProductSale>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "Given invalid product sale data When creating product sale Then throws validation exception")]
        public async Task Handle_InvalidRequest_ThrowsValidationException()
        {
            // Given
            var command = new CreateProductSaleCommand(); // Empty command will fail validation

            // When
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<ValidationException>();
        }

        [Fact(DisplayName = "Given valid command When handling Then maps command to product sale entity")]
        public async Task Handle_ValidRequest_MapsCommandToProductSale()
        {
            // Given
            var command = CreateProductSaleHandlerTestData.GenerateValidCommand();
            var productSale = new ProductSale
            {
                Id = 1,
                ProductId = command.ProductId,
                SaleId = command.SaleId,
                Quantity = command.Quantity,
                UnitPrice = command.UnitPrice,
                Discount = command.Discount,
                TotalItem = command.TotalItem,
                Status = command.Status
            };

            _mapper.Map<ProductSale>(command).Returns(productSale);
            _productSaleRepository.CreateAsync(Arg.Any<ProductSale>(), Arg.Any<CancellationToken>())
                .Returns(productSale);

            // When
            await _handler.Handle(command, CancellationToken.None);

            // Then
            _mapper.Received(1).Map<ProductSale>(Arg.Is<CreateProductSaleCommand>(c =>
                c.ProductId == command.ProductId &&
                c.SaleId == command.SaleId &&
                c.Quantity == command.Quantity &&
                c.UnitPrice == command.UnitPrice &&
                c.Discount == command.Discount &&
                c.TotalItem == command.TotalItem &&
                c.Status == command.Status));
        }
    }
}
