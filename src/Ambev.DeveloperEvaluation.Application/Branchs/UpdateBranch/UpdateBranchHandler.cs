using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch
{
    public class UpdateBranchHandler : IRequestHandler<UpdateBranchCommand, UpdateBranchResult>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        public UpdateBranchHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }
        public async Task<UpdateBranchResult> Handle(UpdateBranchCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateBranchValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var branch = _mapper.Map<Branch>(command);

            var createdBranch = await _branchRepository.UpdateAsync(branch, cancellationToken);
            var result = _mapper.Map<UpdateBranchResult>(createdBranch);
            return result;
        }
    }
}
