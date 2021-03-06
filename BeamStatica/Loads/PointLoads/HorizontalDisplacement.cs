﻿using BeamStatica.Spans.Interfaces;
using System;

namespace BeamStatica.Loads.PointLoads
{
    public class HorizontalDisplacement : SpanConcentratedLoad
    {
        public override bool IncludeInSpanLoadCalculations => true;

        /// <summary>
        /// Use in node loads.
        /// </summary>
        /// <param name="value">mm</param>
        public HorizontalDisplacement(double value) : base(value)
        {
        }

        public override double CalculateHorizontalDisplacement() => this.Value;

        public override double CalculateSpanLoadVectorNormalForceMember(ISpan span, bool leftNode)
        {
            double sign = leftNode ? -1.0 : 1.0;
            if (span.LeftNode.ConcentratedForces.Contains(this))
                sign *= -1;
            return sign * span.Material.YoungModulus * span.Section.Area * Value
                / span.Length / 10; // kN
        }
    }
}
