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
    /// Implementation of ICustomerRepository using Entity Framework Core
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DefaultContext _context;
        /// <summary>
        /// Initializes a new instance of CustomerRepository
        /// context.
        /// </summary>
        /// <param name="context">The database context used to access customer data. Cannot be null.</param>
        public CustomerRepository(DefaultContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creates a new customer in the database
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return customer;
        }

        /// <summary>
        /// Delete a customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
                var customer = await GetByIdAsync(id, cancellationToken);
                if (customer == null)
                    return false;

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
        }

        /// <summary>
        /// Get all customers with pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Customer>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return await _context.Customers
                         .AsNoTracking()
                         .Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize)
                         .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Get a customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Customers.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        /// <summary>
        /// Updates an existing customer in the database
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Customer> UpdateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(cancellationToken);
            return customer;
        }
    }
}
