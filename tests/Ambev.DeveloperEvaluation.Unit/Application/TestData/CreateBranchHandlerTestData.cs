using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    /// <summary>
    /// Provides methods for generating test data for the <see cref="CreateBranchCommand"/> using Bogus.
    /// Ensures that all generated commands are valid for testing CreateBranchHandler scenarios.
    /// </summary>
    public static class CreateBranchHandlerTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid CreateBranchCommand instances.
        /// The generated commands will have valid:
        /// - Name (3-100 characters)
        /// - Email (valid format)
        /// - Phone (Brazilian format)
        /// - Status (Active or Inactive)
        /// </summary>
        private static readonly Faker<CreateBranchCommand> createBranchFaker = new Faker<CreateBranchCommand>("pt_BR")
            .RuleFor(b => b.Name, f => f.Company.CompanyName())
            .RuleFor(b => b.Email, f => f.Internet.Email())
            .RuleFor(b => b.Phone, f => $"+55{f.Random.Number(10, 99)}{f.Random.Number(100000000, 999999999)}")
            .RuleFor(b => b.Status, f => f.PickRandom(BranchStatus.Active, BranchStatus.Inactive));

        /// <summary>
        /// Generates a valid CreateBranchCommand with randomized data.
        /// </summary>
        /// <returns>A valid <see cref="CreateBranchCommand"/> instance.</returns>
        public static CreateBranchCommand GenerateValidCommand()
        {
            return createBranchFaker.Generate();
        }
    }
}
