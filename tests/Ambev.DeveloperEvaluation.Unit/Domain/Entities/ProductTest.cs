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
    /// Contains unit tests for the Product entity class.
    /// Tests cover status changes and validation scenarios.
    /// </summary>
    public class ProductTests
    {
        /// <summary>
        /// Tests that when an inactive product is activated, its status changes to Active.
        /// </summary>
        [Fact(DisplayName = "Product status should change to Active when activated")]
        public void Given_InactiveProduct_When_Activated_Then_StatusShouldBeActive()
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Status = ProductStatus.Inactive;

            // Act
            product.Active();

            // Assert
            Assert.Equal(ProductStatus.Active, product.Status);
        }

        /// <summary>
        /// Tests that when an active product is deactivated, its status changes to Inactive.
        /// </summary>
        [Fact(DisplayName = "Product status should change to Inactive when deactivated")]
        public void Given_ActiveProduct_When_Deactivated_Then_StatusShouldBeInactive()
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Status = ProductStatus.Active;

            // Act
            product.Deactivate();

            // Assert
            Assert.Equal(ProductStatus.Inactive, product.Status);
        }

        /// <summary>
        /// Tests that validation passes when all product properties are valid.
        /// </summary>
        [Fact(DisplayName = "Validation should pass for valid product data")]
        public void Given_ValidProductData_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();

            // Act
            var result = product.Validate();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        /// <summary>
        /// Tests that validation fails when product properties are invalid.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid product data")]
        public void Given_InvalidProductData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var product = new Product
            {
                Description = "", 
                Price = 0,        
                Status = ProductStatus.Inactive
            };

            // Act
            var result = product.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}
