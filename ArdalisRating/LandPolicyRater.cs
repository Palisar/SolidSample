﻿using System;
using System.Collections.Generic;
using System.Text;
using static ArdalisRating.RaterFactory;

namespace ArdalisRating
{
    public class LandPolicyRater : Rater
    {
        private readonly RatingEngine _engine;
        private ConsoleLogger _logger;

        public LandPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
        }
        
        public override void Rate(Policy policy)
        {
            _logger.Log("Rating LAND policy...");
            _logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _logger.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _logger.Log("Insufficient bond amount.");
                return;
            }
            _engine.Rating = policy.BondAmount * 0.05m;
        }
    }
}
