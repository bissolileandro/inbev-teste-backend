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
    /// Contains unit tests for the Customer entity class.
    /// Tests cover status changes and validation scenarios.
    /// </summary>
    public class CustomerTests
    {
        /// <summary>
        /// Tests that when an inactive customer is activated, its status changes to Active.
        /// </summary>
        [Fact(DisplayName = "Customer status should change to Active when activated")]
        public void Given_InactiveCustomer_When_Activated_Then_StatusShouldBeActive()
        {
            // Arrange
            var customer = CustomerTestData.GenerateValidCustomer();
            customer.Status = CustomerStatus.Inactive;

            // Act
            customer.Activate();

            // Assert
            Assert.Equal(CustomerStatus.Active, customer.Status);
        }

        /// <summary>
        /// Tests that when an active customer is deactivated, its status changes to Inactive.
        /// </summary>
        [Fact(DisplayName = "Customer status should change to Inactive when deactivated")]
        public void Given_ActiveCustomer_When_Deactivated_Then_StatusShouldBeInactive()
        {
            // Arrange
            var customer = CustomerTestData.GenerateValidCustomer();
            customer.Status = CustomerStatus.Active;

            // Act
            customer.Deactivate();

            // Assert
            Assert.Equal(CustomerStatus.Inactive, customer.Status);
        }

        /// <summary>
        /// Tests that validation passes when all customer properties are valid.
        /// </summary>
        [Fact(DisplayName = "Validation should pass for valid customer data")]
        public void Given_ValidCustomerData_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var customer = CustomerTestData.GenerateValidCustomer();

            // Act
            var result = customer.Validate();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        /// <summary>
        /// Tests that validation fails when customer properties are invalid.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid customer data")]
        public void Given_InvalidCustomerData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var customer = new Customer
            {
                Name = "", 
                Email = CustomerTestData.GenerateInvalidEmail(),
                Phone = CustomerTestData.GenerateInvalidPhone(),
                Status = CustomerStatus.Inactive
            };

            // Act
            var result = customer.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}
