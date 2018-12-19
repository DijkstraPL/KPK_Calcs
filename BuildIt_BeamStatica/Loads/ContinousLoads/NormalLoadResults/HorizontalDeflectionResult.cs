﻿using Build_IT_BeamStatica.Loads.ContinousLoads.LoadResults;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStatica.Loads.ContinousLoads.NormalLoadResults
{
    public class HorizontalDeflectionResult : DisplacementResultBase
    {
        public HorizontalDeflectionResult(IContinousLoad continousLoad) : base(continousLoad)
        {
        }

        public override double GetValue(ISpan span, double distanceFromLeftSide, double currentLength)
        {
            if (distanceFromLeftSide > ContinousLoad.EndPosition.Position + currentLength)
                return CalculateDeflectionOutsideLoadLength(span, distanceFromLeftSide, currentLength);
            else if (distanceFromLeftSide > ContinousLoad.StartPosition.Position + currentLength)
                return CalculateDeflectionInsideLoadLength(span, distanceFromLeftSide, currentLength);
            return 0;
        }

        private double CalculateDeflectionOutsideLoadLength(ISpan span, double distanceFromLeftSide, double currentLength)
        {
            double distanceFromTheClosestLeftNode = distanceFromLeftSide - currentLength;
            double forceAtX = GetForceAtTheCalculatedPoint(distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position);
            double deflection = 0;

            deflection += ContinousLoad.StartPosition.Value
                * (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 2
                * (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) * 2 / 3
                / (span.Material.YoungModulus * span.Section.Area);
            deflection += forceAtX
                * (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 2
                * (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 3
                / (span.Material.YoungModulus * span.Section.Area);

            deflection -= ContinousLoad.EndPosition.Value
                * (distanceFromTheClosestLeftNode - ContinousLoad.EndPosition.Position) / 2
                * (distanceFromTheClosestLeftNode - ContinousLoad.EndPosition.Position) * 2 / 3
                / (span.Material.YoungModulus * span.Section.Area);
            deflection -= forceAtX
                * (distanceFromTheClosestLeftNode - ContinousLoad.EndPosition.Position) / 2
                * (distanceFromTheClosestLeftNode - ContinousLoad.EndPosition.Position) / 3
                / (span.Material.YoungModulus * span.Section.Area);

            return deflection;
        }

        private double CalculateDeflectionInsideLoadLength(ISpan span, double distanceFromLeftSide, double currentLength)
        {
            double distanceFromTheClosestLeftNode = distanceFromLeftSide - currentLength;
            double forceAtX = GetForceAtTheCalculatedPoint(distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position);
            double deflection = 0;

            deflection += ContinousLoad.StartPosition.Value
                * (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 2
                * (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) * 2 / 3
                / (span.Material.YoungModulus * span.Section.Area);
            deflection += forceAtX
                * (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 2
                * (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 3
                / (span.Material.YoungModulus * span.Section.Area);

            return deflection;
        }
    }
}
