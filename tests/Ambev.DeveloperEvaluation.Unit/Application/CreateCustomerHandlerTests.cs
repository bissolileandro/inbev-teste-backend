using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
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
    public class CreateCustomerHandlerTests
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CreateCustomerHandler _handler;

        public CreateCustomerHandlerTests()
        {
            _customerRepository = Substitute.For<ICustomerRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateCustomerHandler(_customerRepository, _mapper);
        }

        [Fact(DisplayName = "Given valid customer data When creating customer Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = CreateCustomerHandlerTestData.GenerateValidCommand();
            var customer = new Customer
            {
                Id = 1,
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone,
                Status = command.Status
            };

            var result = new CreateCustomerResult
            {
                Id = customer.Id
            };

            _mapper.Map<Customer>(command).Returns(customer);
            _mapper.Map<CreateCustomerResult>(customer).Returns(result);
            _customerRepository.CreateAsync(Arg.Any<Customer>(), Arg.Any<CancellationToken>())
                .Returns(customer);

            // Act
            var createCustomerResult = await _handler.Handle(command, CancellationToken.None);

            // Assert
            createCustomerResult.Should().NotBeNull();
            createCustomerResult.Id.Should().Be(customer.Id);
            await _customerRepository.Received(1).CreateAsync(Arg.Any<Customer>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "Given invalid customer data When creating customer Then throws validation exception")]
        public async Task Handle_InvalidRequest_ThrowsValidationException()
        {
            // Arrange
            var command = new CreateCustomerCommand(); // empty command will fail validation

            // Act
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ValidationException>();
        }

        [Fact(DisplayName = "Given valid command When handling Then maps command to customer entity")]
        public async Task Handle_ValidRequest_MapsCommandToCustomer()
        {
            // Arrange
            var command = CreateCustomerHandlerTestData.GenerateValidCommand();
            var customer = new Customer
            {
                Id = 1,
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone,
                Status = command.Status
            };

            _mapper.Map<Customer>(command).Returns(customer);
            _customerRepository.CreateAsync(Arg.Any<Customer>(), Arg.Any<CancellationToken>())
                .Returns(customer);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mapper.Received(1).Map<Customer>(Arg.Is<CreateCustomerCommand>(c =>
                c.Name == command.Name &&
                c.Email == command.Email &&
                c.Phone == command.Phone &&
                c.Status == command.Status));
        }
    }
}
