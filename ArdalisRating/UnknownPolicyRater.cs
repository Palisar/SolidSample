﻿using System;
using System.Collections.Generic;
using System.Text;
using static ArdalisRating.RaterFactory;

namespace ArdalisRating
{
    internal class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Unknown policy type.");
        }
    }
}
