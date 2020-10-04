using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class LifePolicyRater
    {
        private readonly RatingEngine engine;
        private ConsoleLogger logger;

        public LifePolicyRater(RatingEngine engine, ConsoleLogger logger)

        {
            this.engine = engine;
            this.logger = logger;
        }
        public void Rate(Policy policy)
        {
            logger.Log("Rating LIFE policy...");
            logger.Log("Validating policy.");
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                logger.Log("Life policy must include Date of Birth.");
                return;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                logger.Log("Centenarians are not eligible for coverage.");
                return;
            }
            if (policy.Amount == 0)
            {
                logger.Log("Life policy must include an Amount.");
                return;
            }
            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
            {
                engine.Rating = baseRate * 2;
                return;
            }
            engine.Rating = baseRate;
        }
    }
}
