using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for productSale entity operations
    /// </summary>
    public interface IProductSaleRepository
    {
        /// <summary>
        /// Creates a new productSale in the repository
        /// </summary>
        /// <param name="productSale">The productSale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created productSale</returns>
        Task<ProductSale> CreateAsync(ProductSale productSale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update a productSale in the repository
        /// </summary>
        /// <param name="productSale">The productSale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created productSale</returns>
        Task<ProductSale> UpdateAsync(ProductSale productSale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a productSale by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the productSale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The productSale if found, null otherwise</returns>
        Task<ProductSale?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all productSales by their unique identifier
        /// </summary>        
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The productSale if found, null otherwise</returns>
        Task<List<ProductSale>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);


        /// <summary>
        /// Deletes a productSale from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the productSale to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the productSale was deleted, false if not found</returns>
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
