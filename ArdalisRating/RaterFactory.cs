using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public Rater CreateOld(Policy policy, RatingEngine engine)
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(engine, engine.Logger);

                case PolicyType.Flood:
                    return new FloodPolicyRater(engine, engine.Logger);

                case PolicyType.Life:
                    return new LifePolicyRater(engine, engine.Logger);
                    
                case PolicyType.Land:
                    return new LandPolicyRater(engine, engine.Logger);
                
                default:
                    return new UnknownPolicyRater(engine, engine.Logger);
            }
        }
        //This is the same method as above but using OCP we have made the code open to extension and close to modification
        public Rater Create(Policy policy, RatingEngine engine)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
                    new object[] {engine, engine.Logger});
            }
            catch 
            {
                return new UnknownPolicyRater(engine, engine.Logger);
            }
        }

        public abstract class Rater
        {
            protected readonly RatingEngine _engine;
            protected ConsoleLogger _logger;

            public Rater(RatingEngine engine, ConsoleLogger logger)
            {
                _engine = engine;
                _logger = logger;
            }
            public virtual void Rate(Policy policy)
            {
                //This will be overrided in sub classes.
            }
        }
        
    }
}
