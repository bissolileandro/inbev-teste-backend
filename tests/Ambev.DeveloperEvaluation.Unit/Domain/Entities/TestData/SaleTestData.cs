using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Provides methods to generate test data for the Sale entity.
    /// This class centralizes all Sale test data generation to ensure consistency
    /// across test cases and supports both valid and invalid scenarios.
    /// </summary>
    public static class SaleTestData
    {
        private static readonly Faker<Sale> SaleFaker = new Faker<Sale>("pt_BR")
            .RuleFor(s => s.Id, f => f.Random.Int(1, 1000))
            .RuleFor(s => s.SaleDate, f => f.Date.Recent(30)) 
            .RuleFor(s => s.CustomerId, f => f.Random.Int(1, 100)) 
            .RuleFor(s => s.BranchId, f => f.Random.Int(1, 20))
            .RuleFor(s => s.ProductsSales, (f, s) => ProductSaleTestData.GenerateValidList(f.Random.Int(1, 5), s.Id))
            .RuleFor(s => s.Status, f => f.PickRandom<SaleStatus>()); 

        /// <summary>
        /// Generates a valid Sale with associated products and calculated totals.
        /// </summary>
        /// <returns>A valid Sale entity.</returns>
        public static Sale GenerateValidSale()
        {
            var sale = SaleFaker.Generate();
            sale.CalculateTotals(); 
            return sale;
        }

        /// <summary>
        /// Generates an invalid Sale for testing validation scenarios.
        /// Example: CustomerId or BranchId <= 0, no products, future sale date.
        /// </summary>
        /// <returns>An invalid Sale entity.</returns>
        public static Sale GenerateInvalidSale()
        {
            var sale = new Sale
            {
                SaleDate = DateTime.UtcNow.AddDays(10), 
                CustomerId = 0, 
                BranchId = 0, 
                ProductsSales = new List<ProductSale>(), 
                Status = SaleStatus.Canceled
            };
            sale.CalculateTotals();
            return sale;
        }

        /// <summary>
        /// Generates multiple valid Sale entities.
        /// </summary>
        /// <param name="count">Number of Sale entities to generate.</param>
        /// <returns>List of valid Sale entities.</returns>
        public static List<Sale> GenerateSales(int count = 5)
        {
            var sales = SaleFaker.Generate(count);
            sales.ForEach(s => s.CalculateTotals()); 
            return sales;
        }
    }
}
