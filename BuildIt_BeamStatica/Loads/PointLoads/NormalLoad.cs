﻿using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStatica.Loads.PointLoads
{
    internal class NormalLoad : SpanConcentratedLoad
    {
        /// <summary>
        /// Use in node loads.
        /// </summary>
        /// <param name="value">kN</param>
        /// <param name="position">m</param>
        public NormalLoad(double value) : base(value)
        {
        }

        /// <summary>
        /// Use in span loads.
        /// </summary>
        /// <param name="value">kN</param>
        /// <param name="position">m</param>
        public NormalLoad(double value, double position) : base(value, position)
        {
        }

        public override double CalculateNormalForce() => this.Value;

        public override double CalculateSpanLoadVectorNormalForceMember(ISpan span, bool leftNode)
        {
            double distanceFromCloserNode = leftNode ? this.Position : span.Length - this.Position;
            double distanceFromOtherNode = leftNode ? span.Length - this.Position : this.Position;
            return -this.Value * distanceFromOtherNode / span.Length;
        }

        public override double CalculateJointLoadVectorNormalForceMember() => this.Value;
    }
}
