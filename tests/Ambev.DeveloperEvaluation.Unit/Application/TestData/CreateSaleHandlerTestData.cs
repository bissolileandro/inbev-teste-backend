using Ambev.DeveloperEvaluation.Application.ProductsSales.CreateProductSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
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
    /// Provides methods for generating test data for CreateSaleCommand using Bogus.
    /// Ensures consistent valid and random sale data for unit tests.
    /// </summary>
    public static class CreateSaleHandlerTestData
    {
        private static readonly Faker<CreateSaleCommand> createSaleFaker = new Faker<CreateSaleCommand>()
            .RuleFor(sale => sale.SaleDate, f => f.Date.Recent(30)) // vendas dos últimos 30 dias
            .RuleFor(sale => sale.CustomerId, f => f.Random.Int(1, 500))
            .RuleFor(sale => sale.BranchId, f => f.Random.Int(1, 100))
            .RuleFor(sale => sale.Status, f => f.PickRandom(SaleStatus.Active, SaleStatus.Canceled))
            .RuleFor(sale => sale.ProductsSales, f =>
            {
                // cria de 1 a 5 produtos por venda
                var productSales = new List<CreateProductSaleCommand>();
                int count = f.Random.Int(1, 5);
                for (int i = 0; i < count; i++)
                {
                    var productSale = CreateProductSaleHandlerTestData.GenerateValidCommand();
                    // opcional: calcular TotalItem = Quantity * UnitPrice - Discount
                    productSale.TotalItem = productSale.Quantity * productSale.UnitPrice - productSale.Discount;
                    productSales.Add(productSale);
                }
                return productSales;
            });

        /// <summary>
        /// Generates a valid CreateSaleCommand with randomized data.
        /// </summary>
        /// <returns>A valid CreateSaleCommand instance.</returns>
        public static CreateSaleCommand GenerateValidCommand()
        {
            return createSaleFaker.Generate();
        }
    }
}
