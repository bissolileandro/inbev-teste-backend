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
    public static class ProductSaleTestData
    {
        public static Faker<ProductSale> CreateValidProductSaleFaker()
        {
            return new Faker<ProductSale>("pt_BR")
                .RuleFor(p => p.Id, f => f.Random.Int(1, 1000))
                .RuleFor(p => p.SaleId, f => 0)
                .RuleFor(p => p.Product, f => ProductTestData.GenerateValidProduct())
                .RuleFor(p => p.ProductId, (f, p) => p.Product.Id)
                .RuleFor(p => p.Quantity, f => f.Random.Int(1, 100))
                .RuleFor(p => p.UnitPrice, f => f.Finance.Amount(1, 1000))
                .RuleFor(p => p.Discount, (f, p) => 0)
                .RuleFor(p => p.TotalItem, (f, p) => (p.Quantity * p.UnitPrice) - p.Discount)
                .RuleFor(p => p.Status, f => f.PickRandom<ProductSaleStatus>())
                .RuleFor(p => p.CreatedAt, f => f.Date.PastOffset(1).UtcDateTime)
                .RuleFor(p => p.UpdatedAt, f => f.Date.RecentOffset(1).UtcDateTime);
        }

        public static ProductSale GenerateValid()
        {
            return CreateValidProductSaleFaker().Generate();
        }

        public static ProductSale GenerateProductSaleWhithSalValid()
        {
            var sale = SaleTestData.GenerateValidSale();
            return sale.ProductsSales.First();
        }

        public static List<ProductSale> GenerateValidList(int count = 5, int? saleId = null)
        {
            var products = CreateValidProductSaleFaker().Generate(count);
            if (saleId.HasValue)
            {
                products.ForEach(p => p.SaleId = saleId.Value);
            }
            products.ForEach(p => p.ApplyTotalItem());
            return products;
        }
    }
}
