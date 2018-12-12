using BeamStatica.Spans.Interfaces;
using System;

namespace BeamStatica.Loads.PointLoads
{
    public class VerticalDisplacement : SpanConcentratedLoad
    {
        public override bool IncludeInSpanLoadCalculations => true;

        /// <summary>
        /// Use in node loads.
        /// </summary>
        /// <param name="value">mm</param>
        public VerticalDisplacement(double value) : base(value)
        {
        }

        public override double CalculateVerticalDisplacement() => this.Value;

        public override double CalculateSpanLoadVectorShearMember(ISpan span, bool leftNode)
        {
            double sign = leftNode ? -1.0 : 1.0;
            if (span.LeftNode.ConcentratedForces.Contains(this))
                sign *= -1;
            return sign * 12 * span.Material.YoungModulus * span.Section.MomentOfInteria * Value
                / Math.Pow(span.Length, 3) / 100000; // kN
        }

        public override double CalculateSpanLoadBendingMomentMember(ISpan span, bool leftNode)
        {
            double sign = -1.0;
            if (span.LeftNode.ConcentratedForces.Contains(this))
                sign *= -1;
            return sign * 6 * span.Material.YoungModulus * span.Section.MomentOfInteria * Value
                / Math.Pow(span.Length, 2) / 100000; // kNm
        }

    }
}
