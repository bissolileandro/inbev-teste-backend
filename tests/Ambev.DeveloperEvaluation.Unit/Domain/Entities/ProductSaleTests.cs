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
    /// Contains unit tests for the ProductSale entity class.
    /// Tests cover status changes, total calculation, discounts, and validation scenarios.
    /// </summary>
    public class ProductSaleTests
    {
        /// <summary>
        /// Tests that when a canceled product sale is activated, its status changes to Active.
        /// </summary>
        [Fact(DisplayName = "ProductSale status should change to Active when activated")]
        public void Given_CanceledProductSale_When_Activated_Then_StatusShouldBeActive()
        {
            // Arrange
            var productSale = ProductSaleTestData.GenerateValid();
            productSale.Status = ProductSaleStatus.Canceled;

            // Act
            productSale.Active();

            // Assert
            Assert.Equal(ProductSaleStatus.Active, productSale.Status);
        }

        /// <summary>
        /// Tests that when an active product sale is canceled, its status changes to Canceled.
        /// </summary>
        [Fact(DisplayName = "ProductSale status should change to Canceled when canceled")]
        public void Given_ActiveProductSale_When_Canceled_Then_StatusShouldBeCanceled()
        {
            // Arrange
            var productSale = ProductSaleTestData.GenerateValid();
            productSale.Status = ProductSaleStatus.Active;

            // Act
            productSale.Cancel();

            // Assert
            Assert.Equal(ProductSaleStatus.Canceled, productSale.Status);
        }

        /// <summary>
        /// Tests that ApplyDiscount and ApplyTotalItem calculate totals correctly.
        /// </summary>
        [Fact(DisplayName = "ProductSale should calculate discount and total correctly")]
        public void Given_ProductSale_When_ApplyDiscountAndTotal_Then_TotalsShouldBeCorrect()
        {
            // Arrange
            var productSale = ProductSaleTestData.GenerateValid();
            decimal discountPercent = 0.10m; // 10%

            // Act
            productSale.ApplyDiscount(discountPercent);
            productSale.ApplyTotalItem();

            var expectedDiscount = productSale.Quantity * productSale.UnitPrice * discountPercent;
            var expectedTotal = (productSale.Quantity * productSale.UnitPrice) - expectedDiscount;

            // Assert
            Assert.Equal(expectedDiscount, productSale.Discount);
            Assert.Equal(expectedTotal, productSale.TotalItem);
        }

        /// <summary>
        /// Tests that validation passes when all product sale properties are valid.
        /// </summary>
        [Fact(DisplayName = "Validation should pass for valid ProductSale data")]
        public void Given_ValidProductSaleData_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var productSale = ProductSaleTestData.GenerateProductSaleWhithSalValid();

            // Act
            var result = productSale.Validate();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        /// <summary>
        /// Tests that validation fails when product sale properties are invalid.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid ProductSale data")]
        public void Given_InvalidProductSaleData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var productSale = new ProductSale
            {
                ProductId = 0, 
                SaleId = 0,    
                Quantity = 0,  
                UnitPrice = -1,
                Status = ProductSaleStatus.Active
            };

            // Act
            var result = productSale.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}
