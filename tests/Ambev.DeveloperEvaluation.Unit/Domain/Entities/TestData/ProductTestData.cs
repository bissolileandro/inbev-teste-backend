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
    /// Provides methods for generating test data for Product entity using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class ProductTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid Product entities.
        /// The generated products will have valid:
        /// - Description (between 3 and 200 chars)
        /// - Price (greater than 0)
        /// - Status (Active or Inactive)
        /// </summary>
        private static readonly Faker<Product> ProductFaker = new Faker<Product>()
            .RuleFor(p => p.Id, f => f.Random.Int(1, 1000))
            .RuleFor(p => p.Description, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => Math.Round(f.Random.Decimal(1, 1000), 2))
            .RuleFor(p => p.Status, f => f.PickRandom(ProductStatus.Active, ProductStatus.Inactive));

        /// <summary>
        /// Generates a valid Product entity with randomized data.
        /// </summary>
        /// <returns>A valid Product entity.</returns>
        public static Product GenerateValidProduct()
        {
            return ProductFaker.Generate();
        }

        /// <summary>
        /// Generates a valid description for a product.
        /// </summary>
        /// <returns>A valid product description.</returns>
        public static string GenerateValidDescription()
        {
            return new Faker().Commerce.ProductName();
        }

        /// <summary>
        /// Generates a valid price for a product.
        /// </summary>
        /// <returns>A valid price greater than zero.</returns>
        public static decimal GenerateValidPrice()
        {
            return Math.Round(new Faker().Random.Decimal(1, 1000), 2);
        }

        /// <summary>
        /// Generates an invalid description (too short or empty).
        /// </summary>
        /// <returns>An invalid product description.</returns>
        public static string GenerateInvalidDescription()
        {
            return ""; // vazio ou menor que o mínimo esperado
        }

        /// <summary>
        /// Generates an invalid price (zero or negative).
        /// </summary>
        /// <returns>An invalid product price.</returns>
        public static decimal GenerateInvalidPrice()
        {
            return new Faker().PickRandom(0, -1, -100);
        }

        /// <summary>
        /// Generates a description that exceeds the maximum allowed length.
        /// </summary>
        /// <returns>A product description longer than 200 chars.</returns>
        public static string GenerateLongDescription()
        {
            return new Faker().Random.String2(201);
        }
    }
}
