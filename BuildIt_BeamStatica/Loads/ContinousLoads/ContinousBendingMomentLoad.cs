﻿using Build_IT_BeamStatica.Loads.ContinousLoads.BendingMomentLoadResults;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStatica.Loads.ContinousLoads
{
    internal class ContinousBendingMomentLoad : ContinousLoad
    {
        public static IContinousLoad Create(ISpan span, double value)
        {
            return new ContinousBendingMomentLoad(
                new LoadData(0, value),
                new LoadData(span.Length, value));
        }

        private ContinousBendingMomentLoad(ILoadWithPosition startPosition, ILoadWithPosition endPosition)
            : base(startPosition, endPosition)
        {
            BendingMomentResult = new BendingMomentResult(this);

            RotationResult = new RotationResult(this);
            VerticalDeflectionResult = new VerticalDeflectionResult(this);
        }

        public override double CalculateSpanLoadVectorShearMember(ISpan span, bool leftNode)
        {
            double sign = leftNode ? -1.0 : 1.0;

            return sign * this.EndPosition.Value;
        }
    }
}
