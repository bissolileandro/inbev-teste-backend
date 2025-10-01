using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Contains unit tests for the Sale entity class.
    /// Tests cover status changes, total calculation, and validation scenarios.
    /// </summary>
    public class SaleTests
    {
        /// <summary>
        /// Tests that when a canceled sale is activated, its status changes to Active.
        /// </summary>
        [Fact(DisplayName = "Sale status should change to Active when activated")]
        public void Given_CanceledSale_When_Activated_Then_StatusShouldBeActive()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            sale.Status = SaleStatus.Canceled;

            // Act
            sale.Active();

            // Assert
            Assert.Equal(SaleStatus.Active, sale.Status);
        }

        /// <summary>
        /// Tests that when an active sale is canceled, its status changes to Canceled.
        /// </summary>
        [Fact(DisplayName = "Sale status should change to Canceled when canceled")]
        public void Given_ActiveSale_When_Canceled_Then_StatusShouldBeCanceled()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            sale.Status = SaleStatus.Active;

            // Act
            sale.Cancel();

            // Assert
            Assert.Equal(SaleStatus.Canceled, sale.Status);
        }

        /// <summary>
        /// Tests that CalculateTotals correctly computes total quantities, discounts, and amount.
        /// </summary>
        [Fact(DisplayName = "Sale should calculate totals correctly")]
        public void Given_SaleWithProducts_When_CalculateTotals_Then_TotalsShouldBeCorrect()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();

            // Act
            sale.CalculateTotals();

            var expectedTotalQuantities = sale.ProductsSales
                .Where(ps => ps.Status == ProductSaleStatus.Active)
                .Sum(ps => ps.Quantity);
            var expectedTotalDiscounts = sale.ProductsSales
                .Where(ps => ps.Status == ProductSaleStatus.Active)
                .Sum(ps => ps.Discount);
            var expectedTotalAmount = sale.ProductsSales
                .Where(ps => ps.Status == ProductSaleStatus.Active)
                .Sum(ps => ps.TotalItem);

            // Assert
            Assert.Equal(expectedTotalQuantities, sale.TotalQuantities);
            Assert.Equal(expectedTotalDiscounts, sale.TotalDiscounts);
            Assert.Equal(expectedTotalAmount, sale.TotalAmount);
        }

        /// <summary>
        /// Tests that validation passes when all sale properties are valid.
        /// </summary>
        [Fact(DisplayName = "Validation should pass for valid sale data")]
        public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();

            // Act
            var result = sale.Validate();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        /// <summary>
        /// Tests that validation fails when sale properties are invalid.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid sale data")]
        public void Given_InvalidSaleData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var sale = new Sale
            {
                SaleDate = DateTime.UtcNow.AddDays(10), 
                CustomerId = 0, 
                BranchId = 0,   
                ProductsSales = new List<ProductSale>(), 
                Status = SaleStatus.Canceled
            };

            // Act
            var result = sale.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}
