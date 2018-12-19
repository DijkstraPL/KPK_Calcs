using Build_IT_BeamStatica.Beams.Interfaces;
using Build_IT_BeamStatica.Results.Interfaces;
using Build_IT_BeamStatica.Results.Reactions;
using Build_IT_BeamStatica.Spans;
using Build_IT_BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_BeamStatica.Results.OnSpan
{
    public class NormalForceResult : Result
    {
        public IResultValue Result { get; private set; }
        private double _currentLength;

        public NormalForceResult(IBeam beam) : base(beam)
        {
        }

        protected override IResultValue CalculateAtPosition(double distanceFromLeftSide)
        {
            Result = new NormalForce(distanceFromLeftSide) { Value = 0 };
            _currentLength = 0;

            CalculateNormalForce(distanceFromLeftSide);

            return Result;
        }

        private void CalculateNormalForce(double distanceFromLeftSide)
        {
            foreach (var span in Spans)
            {
                CalculateNormalForceFromNodeForces(span);
                CalculateNormalForceFromContinousLoads(distanceFromLeftSide, span);
                CalculateNormalForceFromPointLoads(distanceFromLeftSide, span);

                _currentLength += span.Length;
                if (distanceFromLeftSide <= _currentLength)
                    break;
            }
        }

        private void CalculateNormalForceFromNodeForces(ISpan span)
        {
            Result.Value += span.LeftNode.NormalForce?.Value ?? 0;
            Result.Value += span.LeftNode.ConcentratedForces.Sum(l => l.CalculateNormalForce());
        }

        private void CalculateNormalForceFromContinousLoads(double distanceFromLeftSide, ISpan span)
        {
            foreach (var load in span.ContinousLoads)
                if (distanceFromLeftSide - _currentLength > load.StartPosition.Position)
                    Result.Value += load.CalculateNormalForce(distanceFromLeftSide - load.StartPosition.Position - _currentLength);
        }

        private void CalculateNormalForceFromPointLoads(double distanceFromLeftSide, ISpan span)
        {
            foreach (var load in span.PointLoads)
                if (distanceFromLeftSide - _currentLength > load.Position)
                    Result.Value += load.CalculateNormalForce();
        }
    }
}
