using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Provides methods for generating test data for Branch entity using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class BranchTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid Branch entities.
        /// The generated branches will have valid:
        /// - Name (between 3 and 100 chars)
        /// - Email (valid format)
        /// - Phone (Brazilian format)
        /// - Status (Active or Inactive)
        /// </summary>
        private static readonly Faker<Branch> BranchFaker = new Faker<Branch>()
            .RuleFor(b => b.Name, f => f.Company.CompanyName())
            .RuleFor(b => b.Email, f => f.Internet.Email())
            .RuleFor(b => b.Phone, f => $"+55{f.Random.Number(11, 99)}{f.Random.Number(100000000, 999999999)}")
            .RuleFor(b => b.Status, f => f.PickRandom(BranchStatus.Active, BranchStatus.Inactive));

        /// <summary>
        /// Generates a valid Branch entity with randomized data.
        /// </summary>
        /// <returns>A valid Branch entity.</returns>
        public static Branch GenerateValidBranch()
        {
            return BranchFaker.Generate();
        }

        /// <summary>
        /// Generates a valid branch name (3-100 chars).
        /// </summary>
        public static string GenerateValidName()
        {
            return new Faker().Company.CompanyName();
        }

        /// <summary>
        /// Generates a valid email address.
        /// </summary>
        public static string GenerateValidEmail()
        {
            return new Faker().Internet.Email();
        }

        /// <summary>
        /// Generates a valid Brazilian phone number.
        /// </summary>
        public static string GenerateValidPhone()
        {
            var faker = new Faker();
            return $"+55{faker.Random.Number(11, 99)}{faker.Random.Number(100000000, 999999999)}";
        }

        /// <summary>
        /// Generates an invalid email address for testing negative scenarios.
        /// </summary>
        public static string GenerateInvalidEmail()
        {
            return new Faker().Lorem.Word();
        }

        /// <summary>
        /// Generates an invalid phone number for testing negative scenarios.
        /// </summary>
        public static string GenerateInvalidPhone()
        {
            return new Faker().Random.AlphaNumeric(5);
        }

        /// <summary>
        /// Generates a branch name shorter than the minimum required length.
        /// </summary>
        public static string GenerateShortName()
        {
            return new Faker().Random.String2(1, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }

        /// <summary>
        /// Generates a branch name longer than the maximum allowed length.
        /// </summary>
        public static string GenerateLongName()
        {
            return new Faker().Random.String2(101);
        }
    }

    
}
