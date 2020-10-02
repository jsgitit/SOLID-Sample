using Newtonsoft.Json;
using System.IO;
using Xunit;

namespace ArdalisRating.Tests
{
    public class RatingEngineRate
    {
        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 200000
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);

            var engine = new RatingEngine();
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(10000, result);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);

            var engine = new RatingEngine();
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(0, result);
        }
        [Fact]

        public void CanCreateLoggerInstance()
        {
            var logger = new ConsoleLogger();

            logger.Log("I'm able to log to the console!");

            Assert.NotNull(logger);
        }

        [Fact]
        public void CanReadFilePolicySource()
        {
            var policySource = new FilePolicySource();

            var policy = policySource.GetPolicyFromSource();

            Assert.NotNull(policy);
            Assert.NotEmpty(policy);

        }
    }
}
