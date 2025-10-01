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
    /// Implementation of IProductSaleRepository using Entity Framework Core
    /// </summary>
    public class ProductSaleRepository : IProductSaleRepository
    {
        private readonly DefaultContext _context;
        /// <summary>
        /// Initializes a new instance of ProductSaleRepository
        /// </summary>
        /// <param name="context"></param>
        public ProductSaleRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new product sale in the database
        /// </summary>
        /// <param name="productSale"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ProductSale> CreateAsync(ProductSale productSale, CancellationToken cancellationToken = default)
        {
            await _context.ProductSales.AddAsync(productSale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return productSale;
        }

        /// <summary>
        /// Delete a product sale by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var productSale = await GetByIdAsync(id, cancellationToken);
            if (productSale == null)
                return false;

            _context.ProductSales.Remove(productSale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Get all product sales with pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<ProductSale>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return await _context.ProductSales
                         .AsNoTracking()
                         .Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize)
                         .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Get a product sale by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProductSale?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.ProductSales.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        /// <summary>
        /// Update a product sale
        /// </summary>
        /// <param name="productSale"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ProductSale> UpdateAsync(ProductSale productSale, CancellationToken cancellationToken = default)
        {
            _context.ProductSales.Update(productSale);
            await _context.SaveChangesAsync(cancellationToken);
            return productSale;
        }
    }
}
