using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
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
    public class CreateBranchHandlerTests
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        private readonly CreateBranchHandler _handler;

        public CreateBranchHandlerTests()
        {
            _branchRepository = Substitute.For<IBranchRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateBranchHandler(_branchRepository, _mapper);
        }

        [Fact(DisplayName = "Given valid branch data When creating branch Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = CreateBranchHandlerTestData.GenerateValidCommand();
            var branch = new Branch
            {
                Id = 1,
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone,
                Status = command.Status
            };

            var result = new CreateBranchResult
            {
                Id = branch.Id
            };

            _mapper.Map<Branch>(command).Returns(branch);
            _mapper.Map<CreateBranchResult>(branch).Returns(result);

            _branchRepository.CreateAsync(Arg.Any<Branch>(), Arg.Any<CancellationToken>())
                .Returns(branch);

            // Act
            var createBranchResult = await _handler.Handle(command, CancellationToken.None);

            // Assert
            createBranchResult.Should().NotBeNull();
            createBranchResult.Id.Should().Be(branch.Id);
            await _branchRepository.Received(1).CreateAsync(Arg.Any<Branch>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "Given invalid branch data When creating branch Then throws validation exception")]
        public async Task Handle_InvalidRequest_ThrowsValidationException()
        {
            // Arrange
            var command = new CreateBranchCommand(); // empty command will fail validation

            // Act
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ValidationException>();
        }

        [Fact(DisplayName = "Given valid command When handling Then maps command to branch entity")]
        public async Task Handle_ValidRequest_MapsCommandToBranch()
        {
            // Arrange
            var command = CreateBranchHandlerTestData.GenerateValidCommand();
            var branch = new Branch
            {
                Id = 1,
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone,
                Status = command.Status
            };

            _mapper.Map<Branch>(command).Returns(branch);
            _branchRepository.CreateAsync(Arg.Any<Branch>(), Arg.Any<CancellationToken>())
                .Returns(branch);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mapper.Received(1).Map<Branch>(Arg.Is<CreateBranchCommand>(c =>
                c.Name == command.Name &&
                c.Email == command.Email &&
                c.Phone == command.Phone &&
                c.Status == command.Status));
        }
    }
}
