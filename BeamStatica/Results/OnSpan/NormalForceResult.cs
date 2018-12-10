using BeamStatica.Results.Interfaces;
using BeamStatica.Results.Reactions;
using BeamStatica.Spans;
using BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeamStatica.Results.OnSpan
{
    public class NormalForceResult : IGetResult
    {
        public IResultValue Result { get; private set; }
        private IList<ISpan> _spans;
        private double _currentLength;

        public NormalForceResult(IList<ISpan> spans)
        {
            _spans = spans ?? throw new ArgumentNullException(nameof(spans));
        }

        public IResultValue GetValue(double distanceFromLeftSide)
        {
            Result = new ShearForce() { Value = 0 };
            _currentLength = 0;

            CalculateNormalForce(distanceFromLeftSide);

            return Result;
        }

        private void CalculateNormalForce(double distanceFromLeftSide)
        {
            foreach (var span in _spans)
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
