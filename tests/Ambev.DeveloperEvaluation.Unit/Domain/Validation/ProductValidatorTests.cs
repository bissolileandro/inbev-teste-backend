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
    /// Contains unit tests for the ProductValidator class.
    /// Tests cover validation of all Product properties including
    /// Description and Price requirements.
    /// </summary>
    public class ProductValidatorTests
    {
        private readonly ProductValidator _validator;

        public ProductValidatorTests()
        {
            _validator = new ProductValidator();
        }

        /// <summary>
        /// Tests that validation passes when all Product properties are valid.
        /// This test verifies that a Product with valid:
        /// - Description (3-100 characters)
        /// - Price (>0)
        /// passes all validation rules without any errors.
        /// </summary>
        [Fact(DisplayName = "Valid Product should pass all validation rules")]
        public void Given_ValidProduct_When_Validated_Then_ShouldNotHaveErrors()
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Tests that validation fails when Description is empty or too short.
        /// </summary>
        [Theory(DisplayName = "Empty or too short Description should fail validation")]
        [InlineData("")]
        [InlineData("ab")]
        public void Given_InvalidDescription_When_Validated_Then_ShouldHaveError(string description)
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Description = description;

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        /// <summary>
        /// Tests that validation fails when Description exceeds maximum length.
        /// </summary>
        [Fact(DisplayName = "Description longer than maximum length should fail validation")]
        public void Given_DescriptionLongerThanMaximum_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Description = new string('A', 101);

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        /// <summary>
        /// Tests that validation fails when Price is zero or negative.
        /// </summary>
        [Theory(DisplayName = "Price less than or equal to zero should fail validation")]
        [InlineData(0)]
        [InlineData(-10)]
        public void Given_InvalidPrice_When_Validated_Then_ShouldHaveError(decimal price)
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.Price = price;

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Price);
        }
    }
}
