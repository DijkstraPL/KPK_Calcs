﻿using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;
using System;

namespace BeamStatica.Loads.PointLoads
{
    public class BendingMoment : SpanConcentratedLoad
    {
        /// <summary>
        /// Use in node loads.
        /// </summary>
        /// <param name="value">kNm</param>
        public BendingMoment(double value) : base(value)
        {
        }

        /// <summary>
        /// Use in span loads.
        /// </summary>
        /// <param name="value">kNm</param>
        /// <param name="position">m</param>
        public BendingMoment(double value, double position) : base(value, position)
        {
        }

        public override double CalculateBendingMoment(double distanceFromLoad)
            => this.Value;
        
        public override double CalculateSpanLoadVectorShearMember(ISpan span, bool leftNode)
        {
            double sign = leftNode ? -1.0 : 1.0;
            double distanceFromCloserNode = leftNode ? this.Position : span.Length - this.Position;
            double distanceFromOtherNode = leftNode ? span.Length - this.Position : this.Position;
            return (sign * 6 * this.Value * distanceFromCloserNode * distanceFromOtherNode) / Math.Pow(span.Length, 3);
        }

        public override double CalculateSpanLoadBendingMomentMember(ISpan span, bool leftNode)
        {
            double distanceFromCloserNode = leftNode ? this.Position : span.Length - this.Position;
            double distanceFromOtherNode = leftNode ? span.Length - this.Position : this.Position;
            return (-this.Value * distanceFromOtherNode
                * (2 * distanceFromCloserNode - distanceFromOtherNode))
                / Math.Pow(span.Length, 2);
        }

        public override double CalculateJointLoadVectorBendingMomentMember() => -this.Value;
    }
}
