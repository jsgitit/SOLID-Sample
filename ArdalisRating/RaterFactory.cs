using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            switch (policy.Type)
            {
                case PolicyType.Life:
                    return new AutoPolicyRater(engine, engine.Logger);
                case PolicyType.Land:
                    return new LandPolicyRater(engine, engine.Logger);
                case PolicyType.Auto:
                    return new AutoPolicyRater(engine, engine.Logger);
                case PolicyType.Flood:
                    return new FloodPolicyRater(engine, engine.Logger);
                default:
                    // TODO: Implement Null Object Pattern
                    // Logger.Log("Unknown Policy Type");
                    return new UnknownPolicyRater(engine, engine.Logger);
                    break;
            }
        }
    }
}
