using Ambev.DeveloperEvaluation.Application.ProductsSales.CreateProductSale;
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
    /// Provides methods for generating test data for CreateProductSaleCommand using Bogus.
    /// Ensures consistent valid and random product sale data for unit tests.
    /// </summary>
    public static class CreateProductSaleHandlerTestData
    {
        private static readonly Faker<CreateProductSaleCommand> createProductSaleFaker = new Faker<CreateProductSaleCommand>()
            .RuleFor(ps => ps.SaleId, f => f.Random.Int(1, 500))
            .RuleFor(ps => ps.ProductId, f => f.Random.Int(1, 500))
            .RuleFor(ps => ps.Quantity, f => f.Random.Int(1, 20))
            .RuleFor(ps => ps.UnitPrice, f => Math.Round(f.Random.Decimal(1, 1000), 2))
            .RuleFor(ps => ps.Discount, f => 0m) // Pode ser calculado no teste se necessário
            .RuleFor(ps => ps.TotalItem, f => 0m) // Será calculado a partir de Quantity * UnitPrice - Discount
            .RuleFor(ps => ps.Status, f => f.PickRandom(ProductSaleStatus.Active, ProductSaleStatus.Canceled));

        /// <summary>
        /// Generates a valid CreateProductSaleCommand with randomized data.
        /// </summary>
        /// <returns>A valid CreateProductSaleCommand instance.</returns>
        public static CreateProductSaleCommand GenerateValidCommand()
        {
            return createProductSaleFaker.Generate();
        }
    }
}
