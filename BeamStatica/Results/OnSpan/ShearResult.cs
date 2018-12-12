using BeamStatica.Results.Interfaces;
using BeamStatica.Results.Reactions;
using BeamStatica.Spans;
using BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeamStatica.Results.OnSpan
{
    public class ShearResult : IGetResult
    {
        public IResultValue Result { get; private set; }
        private IList<ISpan> _spans { get; }
        private double _currentLength;

        public ShearResult(IList<ISpan> spans)
        {
            _spans = spans ?? throw new ArgumentNullException(nameof(spans));
        }
        
        public IResultValue GetValue(double distanceFromLeftSide)
        {
            Result = new ShearForce() { Value = 0 };
            _currentLength = 0;

            CalculateShear(distanceFromLeftSide);

            return Result;
        }

        private void CalculateShear(double distanceFromLeftSide)
        {
            foreach (var span in _spans)
            {
                CalculateShearForceFromNodeForces(span);
                CalculateShearFromContinousLoads(distanceFromLeftSide, span);
                CalculateShearFromPointLoads(distanceFromLeftSide, span);

                _currentLength += span.Length;
                if (distanceFromLeftSide <= _currentLength)
                    break;
            }
        }

        private void CalculateShearForceFromNodeForces(ISpan span)
        {
            Result.Value += span.LeftNode.ShearForce?.Value ?? 0;
            Result.Value += span.LeftNode.ConcentratedForces.Sum(l => l.CalculateShear());
        }

        private void CalculateShearFromContinousLoads(double distanceFromLeftSide, ISpan span)
        {
            foreach (var load in span.ContinousLoads)
                if (distanceFromLeftSide - _currentLength > load.StartPosition.Position)
                    Result.Value += load.CalculateShear(distanceFromLeftSide - load.StartPosition.Position - _currentLength);
        }

        private void CalculateShearFromPointLoads(double distanceFromLeftSide, ISpan span)
        {
            foreach (var load in span.PointLoads)
                if (distanceFromLeftSide - _currentLength > load.Position)
                    Result.Value += load.CalculateShear();
        }
    }
}
