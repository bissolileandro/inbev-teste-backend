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
    /// Contains unit tests for the Branch entity class.
    /// Tests cover status changes and validation scenarios.
    /// </summary>
    public class BranchTests
    {
        /// <summary>
        /// Tests that when an inactive branch is activated, its status changes to Active.
        /// </summary>
        [Fact(DisplayName = "Branch status should change to Active when activated")]
        public void Given_InactiveBranch_When_Activated_Then_StatusShouldBeActive()
        {
            // Arrange
            var branch = BranchTestData.GenerateValidBranch();
            branch.Status = BranchStatus.Inactive;

            // Act
            branch.Activate();

            // Assert
            Assert.Equal(BranchStatus.Active, branch.Status);
        }

        /// <summary>
        /// Tests that when an active branch is deactivated, its status changes to Inactive.
        /// </summary>
        [Fact(DisplayName = "Branch status should change to Inactive when deactivated")]
        public void Given_ActiveBranch_When_Deactivated_Then_StatusShouldBeInactive()
        {
            // Arrange
            var branch = BranchTestData.GenerateValidBranch();
            branch.Status = BranchStatus.Active;

            // Act
            branch.Deactivate();

            // Assert
            Assert.Equal(BranchStatus.Inactive, branch.Status);
        }

        /// <summary>
        /// Tests that validation passes when all branch properties are valid.
        /// </summary>
        [Fact(DisplayName = "Validation should pass for valid branch data")]
        public void Given_ValidBranchData_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var branch = BranchTestData.GenerateValidBranch();

            // Act
            var result = branch.Validate();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        /// <summary>
        /// Tests that validation fails when branch properties are invalid.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid branch data")]
        public void Given_InvalidBranchData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var branch = new Branch
            {
                Name = "", 
                Email = BranchTestData.GenerateInvalidEmail(), 
                Phone = BranchTestData.GenerateInvalidPhone(), 
                Status = BranchStatus.Inactive 
            };

            // Act
            var result = branch.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}
