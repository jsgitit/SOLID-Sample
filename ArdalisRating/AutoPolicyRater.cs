using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class AutoPolicyRater : Rater
    {
        private readonly RatingEngine engine;
        private ConsoleLogger logger;

        public AutoPolicyRater(RatingEngine engine, ConsoleLogger logger) 
            : base(engine, logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public override void Rate(Policy policy)
        {
            logger.Log("Rating AUTO policy...");
            logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                logger.Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    engine.Rating = 1000m;
                }
                engine.Rating = 900m;
            }
        }
    }
}
