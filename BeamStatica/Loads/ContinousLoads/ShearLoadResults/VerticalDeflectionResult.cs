﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeamStatica.Loads.ContinousLoads.LoadResults;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;

namespace BeamStatica.Loads.ContinousLoads.ShearLoadResults
{
    public class VerticalDeflectionResult : DisplacementResultBase
    {
        public VerticalDeflectionResult(IContinousLoad continousLoad) : base(continousLoad)
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

            deflection += ContinousLoad.StartPosition.Value *
                (distanceFromTheClosestLeftNode- ContinousLoad.StartPosition.Position) / 2 *
                (distanceFromTheClosestLeftNode- ContinousLoad.StartPosition.Position) / 3 *
                (distanceFromTheClosestLeftNode- ContinousLoad.StartPosition.Position) / 4 *
                (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) * 4 / 5
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            deflection += forceAtX *
                (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 2 *
                (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 3 *
                (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 4 *
                (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 5
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);

            deflection -= ContinousLoad.EndPosition.Value *
                (distanceFromTheClosestLeftNode - ContinousLoad.EndPosition.Position) / 2 *
                (distanceFromTheClosestLeftNode - ContinousLoad.EndPosition.Position) / 3 *
                (distanceFromTheClosestLeftNode - ContinousLoad.EndPosition.Position) / 4 *
                (distanceFromTheClosestLeftNode - ContinousLoad.EndPosition.Position) * 4 / 5
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            deflection -= forceAtX *
                (distanceFromTheClosestLeftNode - ContinousLoad.EndPosition.Position) / 2 *
                (distanceFromTheClosestLeftNode - ContinousLoad.EndPosition.Position) / 3 *
                (distanceFromTheClosestLeftNode - ContinousLoad.EndPosition.Position) / 4 *
                (distanceFromTheClosestLeftNode - ContinousLoad.EndPosition.Position) / 5
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);

            return deflection;
        }

        private double CalculateDeflectionInsideLoadLength(ISpan span, double distanceFromLeftSide, double currentLength)
        {
            double distanceFromTheClosestLeftNode = distanceFromLeftSide - currentLength;
            double forceAtX = GetForceAtTheCalculatedPoint(distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position);
            double deflection = 0;

            deflection += ContinousLoad.StartPosition.Value *
               (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 2 *
               (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 3 *
               (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 4 *
               (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) * 4 / 5
               / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            deflection += forceAtX *
                (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 2 *
                (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 3 *
                (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 4 *
                (distanceFromTheClosestLeftNode - ContinousLoad.StartPosition.Position) / 5
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);

            return deflection;
        }
    }
}
