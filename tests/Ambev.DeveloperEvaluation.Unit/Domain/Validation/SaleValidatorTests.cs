using Ambev.DeveloperEvaluation.Domain.Entities;
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
    /// Contains unit tests for the SaleValidator class.
    /// Tests cover validation of Sale properties including:
    /// SaleDate, BranchId, CustomerId, and ProductsSales.
    /// </summary>
    public class SaleValidatorTests
    {
        private readonly SaleValidator _validator;

        public SaleValidatorTests()
        {
            _validator = new SaleValidator();
        }

        /// <summary>
        /// Tests that validation passes when all Sale properties are valid.
        /// This test verifies that a Sale with valid:
        /// - SaleDate (not in the future)
        /// - BranchId (>0)
        /// - CustomerId (>0)
        /// - ProductSales (each valid)
        /// passes all validation rules without any errors.
        /// </summary>
        [Fact(DisplayName = "Valid Sale should pass all validation rules")]
        public void Given_ValidSale_When_Validated_Then_ShouldNotHaveErrors()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();

            // Act
            var result = _validator.TestValidate(sale);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Tests that validation fails when SaleDate is in the future.
        /// </summary>
        [Fact(DisplayName = "SaleDate in the future should fail validation")]
        public void Given_SaleDateInFuture_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            sale.SaleDate = DateTime.UtcNow.AddDays(1);

            // Act
            var result = _validator.TestValidate(sale);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.SaleDate);
        }

        /// <summary>
        /// Tests that validation fails when BranchId is zero or negative.
        /// </summary>
        [Theory(DisplayName = "BranchId less than or equal to zero should fail validation")]
        [InlineData(0)]
        [InlineData(-5)]
        public void Given_InvalidBranchId_When_Validated_Then_ShouldHaveError(int branchId)
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            sale.BranchId = branchId;

            // Act
            var result = _validator.TestValidate(sale);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.BranchId);
        }

        /// <summary>
        /// Tests that validation fails when CustomerId is zero or negative.
        /// </summary>
        [Theory(DisplayName = "CustomerId less than or equal to zero should fail validation")]
        [InlineData(0)]
        [InlineData(-10)]
        public void Given_InvalidCustomerId_When_Validated_Then_ShouldHaveError(int customerId)
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            sale.CustomerId = customerId;

            // Act
            var result = _validator.TestValidate(sale);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CustomerId);
        }

        /// <summary>
        /// Tests that validation fails when one of the ProductSales is invalid.
        /// </summary>
        [Fact(DisplayName = "Invalid ProductSale in Sale should fail validation")]
        public void Given_InvalidProductSale_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            var invalidProductSale = sale.ProductsSales.First();
            invalidProductSale.Quantity = 0; 
            sale.ProductsSales = new System.Collections.Generic.List<ProductSale> { invalidProductSale };

            // Act
            var result = _validator.TestValidate(sale);

            // Assert
            Assert.Single(result.Errors); 
            result.ShouldHaveValidationErrorFor("ProductsSales[0].Quantity");
        }
    }
}
