﻿using Build_IT_BeamStatica.Loads.ContinousLoads.LoadResults;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.BendingMomentLoadResults
{
    public class VerticalDeflectionResult : DisplacementResultBase
    {
        public VerticalDeflectionResult(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        public override double GetValue(ISpan span, double distanceFromLeftSide, double currentLength)
        {
            double distanceFromTheClosestLeftNode = distanceFromLeftSide - currentLength;

            return ContinousLoad.StartPosition.Value
                * distanceFromTheClosestLeftNode
                * distanceFromTheClosestLeftNode / 2
                * distanceFromTheClosestLeftNode / 3
               / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }
    }
}