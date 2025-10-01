using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
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
    public class CreateSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _productRepository = Substitute.For<IProductRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateSaleHandler(_saleRepository, _productRepository, _mapper);
        }

        [Fact(DisplayName = "Given valid sale data When creating sale Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = CreateSaleHandlerTestData.GenerateValidCommand();
            var sale = new Sale
            {
                Id = 1,
                CustomerId = command.CustomerId,
                BranchId = command.BranchId,
                SaleDate = command.SaleDate,
                Status = command.Status,
                ProductsSales = command.ProductsSales.Select(ps => new ProductSale
                {
                    Id = ps.ProductId,
                    ProductId = ps.ProductId,
                    SaleId = ps.SaleId,
                    Quantity = ps.Quantity,
                    UnitPrice = ps.UnitPrice,
                    Discount = ps.Discount,
                    TotalItem = ps.TotalItem,
                    Status = ps.Status
                }).ToList()
            };

            var result = new CreateSaleResult
            {
                Id = sale.Id
            };

            _mapper.Map<Sale>(command).Returns(sale);
            _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);
            _saleRepository.GetByIdAsync(sale.Id, Arg.Any<CancellationToken>()).Returns(sale);
            _mapper.Map<CreateSaleResult>(sale).Returns(result);

            // When
            var createSaleResult = await _handler.Handle(command, CancellationToken.None);

            // Then
            createSaleResult.Should().NotBeNull();
            createSaleResult.Id.Should().Be(sale.Id);
            await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "Given invalid sale data When creating sale Then throws validation exception")]
        public async Task Handle_InvalidRequest_ThrowsValidationException()
        {
            // Given
            var command = new CreateSaleCommand(); // Empty command will fail validation

            // When
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<ValidationException>();
        }

        [Fact(DisplayName = "Given valid command When handling Then maps command to sale entity")]
        public async Task Handle_ValidRequest_MapsCommandToSale()
        {
            // Given
            var command = CreateSaleHandlerTestData.GenerateValidCommand();
            var sale = new Sale
            {
                Id = 1,
                CustomerId = command.CustomerId,
                BranchId = command.BranchId,
                SaleDate = command.SaleDate,
                Status = command.Status
            };

            _mapper.Map<Sale>(command).Returns(sale);
            _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);
            _saleRepository.GetByIdAsync(sale.Id, Arg.Any<CancellationToken>()).Returns(sale);

            // When
            await _handler.Handle(command, CancellationToken.None);

            // Then
            _mapper.Received(1).Map<Sale>(Arg.Is<CreateSaleCommand>(c =>
                c.CustomerId == command.CustomerId &&
                c.BranchId == command.BranchId &&
                c.SaleDate == command.SaleDate &&
                c.Status == command.Status));
        }
    }
}
