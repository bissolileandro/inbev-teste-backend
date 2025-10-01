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
    /// Contains unit tests for the CustomerValidator class.
    /// Tests cover validation of all customer properties including
    /// name, email, and phone requirements.
    /// </summary>
    public class CustomerValidatorTests
    {
        private readonly CustomerValidator _validator;

        public CustomerValidatorTests()
        {
            _validator = new CustomerValidator();
        }

        /// <summary>
        /// Tests that validation passes when all customer properties are valid.
        /// This test verifies that a customer with valid:
        /// - Name (3-100 characters)
        /// - Email (valid format)
        /// - Phone (valid Brazilian format)
        /// passes all validation rules without any errors.
        /// </summary>
        [Fact(DisplayName = "Valid customer should pass all validation rules")]
        public void Given_ValidCustomer_When_Validated_Then_ShouldNotHaveErrors()
        {
            // Arrange
            var customer = CustomerTestData.GenerateValidCustomer();

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Tests that validation fails for invalid customer name formats.
        /// This test verifies that names that are:
        /// - Empty strings
        /// - Less than 3 characters
        /// fail validation with appropriate error messages.
        /// </summary>
        /// <param name="name">The invalid customer name to test.</param>
        [Theory(DisplayName = "Invalid customer name formats should fail validation")]
        [InlineData("")] // Empty
        [InlineData("AB")] // Less than 3 characters
        public void Given_InvalidName_When_Validated_Then_ShouldHaveError(string name)
        {
            // Arrange
            var customer = CustomerTestData.GenerateValidCustomer();
            customer.Name = name;

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        /// <summary>
        /// Tests that validation fails when customer name exceeds maximum length.
        /// This test verifies that names longer than 100 characters fail validation.
        /// </summary>
        [Fact(DisplayName = "Customer name longer than maximum length should fail validation")]
        public void Given_NameLongerThanMaximum_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var customer = CustomerTestData.GenerateValidCustomer();
            customer.Name = new string('A', 101); // Exceed max length

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        /// <summary>
        /// Tests that validation fails for invalid email formats.
        /// This test verifies that emails that:
        /// - Don't follow the standard email format (user@domain.com)
        /// - Don't contain @ symbol
        /// fail validation with appropriate error messages.
        /// </summary>
        [Fact(DisplayName = "Invalid email formats should fail validation")]
        public void Given_InvalidEmail_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var customer = CustomerTestData.GenerateValidCustomer();
            customer.Email = CustomerTestData.GenerateInvalidEmail();

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        /// <summary>
        /// Tests that validation fails for invalid phone formats.
        /// This test verifies that phone numbers that:
        /// - Don't follow the Brazilian phone number format (+55XXXXXXXXXXXX)
        /// - Don't have the correct length
        /// - Don't start with the country code (+55)
        /// fail validation with appropriate error messages.
        /// </summary>
        [Fact(DisplayName = "Invalid phone formats should fail validation")]
        public void Given_InvalidPhone_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var customer = CustomerTestData.GenerateValidCustomer();
            customer.Phone = CustomerTestData.GenerateInvalidPhone();

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Phone);
        }
    }
}
