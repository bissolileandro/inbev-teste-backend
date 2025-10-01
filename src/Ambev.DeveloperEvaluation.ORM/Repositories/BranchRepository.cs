using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IBranchRepository using Entity Framework Core
    /// </summary>    
    public class BranchRepository : IBranchRepository
    {
        private readonly DefaultContext _context;
        /// <summary>
        /// Initializes a new instance of BranchRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public BranchRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new branch in the database
        /// </summary>
        /// <param name="branch"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default)
        {
            await _context.Branches.AddAsync(branch, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return branch;
        }

        /// <summary>
        /// Delete a branch by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var branch = await GetByIdAsync(id, cancellationToken);
            if (branch == null)
                return false;

            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Get all branches with pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Branch>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return await _context.Branches
                         .AsNoTracking() 
                         .Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize)
                         .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Get a branch by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Branch?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Branches.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        /// <summary>
        /// Update a branch
        /// </summary>
        /// <param name="branch"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Branch> UpdateAsync(Branch branch, CancellationToken cancellationToken = default)
        {
            _context.Branches.Update(branch);
            await _context.SaveChangesAsync(cancellationToken);
            return branch;
        }
    }
}
