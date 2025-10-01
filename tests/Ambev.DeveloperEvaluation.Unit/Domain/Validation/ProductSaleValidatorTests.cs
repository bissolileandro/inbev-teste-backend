using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    /// <summary>
    /// Contains unit tests for the ProductSaleValidator class.
    /// Tests cover validation of all ProductSale properties including
    /// ProductId, SaleId, Quantity, and UnitPrice requirements.
    /// </summary>
    public class ProductSaleValidatorTests
    {
        private readonly ProductSaleValidator _validator;

        public ProductSaleValidatorTests()
        {
            _validator = new ProductSaleValidator();
        }

        /// <summary>
        /// Tests that validation passes when all ProductSale properties are valid.
        /// This test verifies that a ProductSale with valid:
        /// - ProductId
        /// - SaleId
        /// - Quantity (>0)
        /// - UnitPrice (>=0)
        /// passes all validation rules without any errors.
        /// </summary>
        [Fact(DisplayName = "Valid ProductSale should pass all validation rules")]
        public void Given_ValidProductSale_When_Validated_Then_ShouldNotHaveErrors()
        {
            // Arrange
            var productSale = ProductSaleTestData.GenerateProductSaleWhithSalValid();

            // Act
            var result = _validator.TestValidate(productSale);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Tests that validation fails when ProductId is empty.
        /// </summary>
        [Fact(DisplayName = "Empty ProductId should fail validation")]
        public void Given_EmptyProductId_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var productSale = ProductSaleTestData.GenerateValid();
            productSale.ProductId = 0;

            // Act
            var result = _validator.TestValidate(productSale);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ProductId);
        }

        /// <summary>
        /// Tests that validation fails when SaleId is empty.
        /// </summary>
        [Fact(DisplayName = "Empty SaleId should fail validation")]
        public void Given_EmptySaleId_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var productSale = ProductSaleTestData.GenerateValid();
            productSale.SaleId = 0;

            // Act
            var result = _validator.TestValidate(productSale);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.SaleId);
        }

        /// <summary>
        /// Tests that validation fails when Quantity is zero or negative.
        /// </summary>
        [Theory(DisplayName = "Quantity less than or equal to zero should fail validation")]
        [InlineData(0)]
        [InlineData(-5)]
        public void Given_InvalidQuantity_When_Validated_Then_ShouldHaveError(int quantity)
        {
            // Arrange
            var productSale = ProductSaleTestData.GenerateValid();
            productSale.Quantity = quantity;

            // Act
            var result = _validator.TestValidate(productSale);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Quantity);
        }

        /// <summary>
        /// Tests that validation fails when UnitPrice is negative.
        /// </summary>
        [Fact(DisplayName = "Negative UnitPrice should fail validation")]
        public void Given_NegativeUnitPrice_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var productSale = ProductSaleTestData.GenerateValid();
            productSale.UnitPrice = -10m;

            // Act
            var result = _validator.TestValidate(productSale);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.UnitPrice);
        }
    }
}
