using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
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
    /// Provides methods for generating test data for the <see cref="CreateCustomerCommand"/> using Bogus.
    /// Ensures that all generated commands are valid for testing CreateCustomerHandler scenarios.
    /// </summary>
    public static class CreateCustomerHandlerTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid CreateCustomerCommand instances.
        /// The generated commands will have valid:
        /// - Name (3-100 characters)
        /// - Email (valid format)
        /// - Phone (Brazilian format)
        /// - Status (Active or Inactive)
        /// </summary>
        private static readonly Faker<CreateCustomerCommand> createCustomerFaker = new Faker<CreateCustomerCommand>("pt_BR")
            .RuleFor(c => c.Name, f => f.Name.FullName())
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Phone, f => $"+55{f.Random.Number(10, 99)}{f.Random.Number(100000000, 999999999)}")
            .RuleFor(c => c.Status, f => f.PickRandom(CustomerStatus.Active, CustomerStatus.Inactive));

        /// <summary>
        /// Generates a valid CreateCustomerCommand with randomized data.
        /// </summary>
        /// <returns>A valid <see cref="CreateCustomerCommand"/> instance.</returns>
        public static CreateCustomerCommand GenerateValidCommand()
        {
            return createCustomerFaker.Generate();
        }
    }
}
