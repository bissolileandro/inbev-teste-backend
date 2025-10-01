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

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetAllBranchs
{
    /// <summary>
    /// Handler for getting all branchs with pagination
    /// </summary>
    public class GetAllBranchHandler : IRequestHandler<GetAllBranchCommand, GetAllBranchPaginedResult>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        public GetAllBranchHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }
        public async Task<GetAllBranchPaginedResult> Handle(GetAllBranchCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetAllBranchValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var listBranch = _mapper.Map<List<GetAllBranchResult>>(await _branchRepository.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken));
            if (listBranch == null)
                throw new KeyNotFoundException($"branch's not found");

            return new GetAllBranchPaginedResult
            {
                Items = listBranch,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize                
            };
        }
    }
}
