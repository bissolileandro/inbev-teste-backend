using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    /// <summary>
    /// Provides methods for generating test data for CreateProductCommand using Bogus.
    /// Ensures consistent valid and random product data for unit tests.
    /// </summary>
    public static class CreateProductHandlerTestData
    {
        private static readonly Faker<CreateProductCommand> createProductHandlerFaker = new Faker<CreateProductCommand>()
            .RuleFor(p => p.Description, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => Math.Round(f.Random.Decimal(1, 1000), 2))
            .RuleFor(p => p.Status, f => f.PickRandom(ProductStatus.Active, ProductStatus.Inactive));

        /// <summary>
        /// Generates a valid CreateProductCommand with randomized data.
        /// </summary>
        /// <returns>A valid CreateProductCommand instance.</returns>
        public static CreateProductCommand GenerateValidCommand()
        {
            return createProductHandlerFaker.Generate();
        }
    }
}
