using BeamStatica.Loads.PointLoads;
using BeamStatica.Nodes;
using BeamStatica.Results.Displacements;
using BeamStatica.Results.Interfaces;
using BeamStatica.Spans;
using System;
using System.Linq;

namespace BeamStatica.Results.OnSpan
{
    public class RotationResult : IGetResult
    {
        public IResultValue Result { get; private set; }
        private double _currentLength;
        private double _distanceFromLeftSide;

        private double _spanRotation;
        private readonly Beam _beam;
        private readonly bool _adjustRotation;

        public RotationResult(Beam beam)
        {
            _beam = beam ?? throw new ArgumentNullException(nameof(beam));
        }

        private RotationResult(Beam beam, bool adjustRotation)
        {
            _beam = beam ?? throw new ArgumentNullException(nameof(beam));
            _adjustRotation = adjustRotation;
        }

        public IResultValue GetValue(double distanceFromLeftSide)
        {
            _distanceFromLeftSide = distanceFromLeftSide;
            Result = new Rotation() { Value = 0 };

            _currentLength = 0;

            _spanRotation = 0;

            CalculateRotation();

            _spanRotation *= 100;

            Result.Value += _spanRotation;

            return Result;
        }

        private void CalculateRotation()
        {
            double calculatedLength = 0;
            foreach (var span in _beam.Spans)
            {
                calculatedLength += span.Length;
                if (calculatedLength <= _distanceFromLeftSide &&
                    !IsLastNode(span))
                {
                    _currentLength += span.Length;
                    continue;
                }

                if (_distanceFromLeftSide < _currentLength)
                {
                    _currentLength += span.Length;
                    continue;
                }

                CalculateRotationFromCalculatedForcesAndDisplacements(span);
                CalculateRotationFromNodeForces(span);
                CalculateRotationFromContinousLoads(span);
                CalculateRotationFromPointLoads(span);

                _currentLength += span.Length;
            }
        }
        
        private bool IsLastNode(Span span) =>
            span == _beam.Spans.Last() && _distanceFromLeftSide == _beam.Length;

        private void CalculateRotationFromCalculatedForcesAndDisplacements(Span span)
        {
            _spanRotation += span.LeftNode.RightRotation?.Value / 100 ?? 0;

            if (_currentLength != 0)
            {
                _spanRotation += _beam.ShearResult.GetValue(_currentLength).Value
                * (_distanceFromLeftSide - _currentLength)
                * (_distanceFromLeftSide - _currentLength) / 2
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);

                _spanRotation += _beam.BendingMomentResult.GetValue(_currentLength).Value
                    * (_distanceFromLeftSide - _currentLength)
                    / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            }
        }

        private void CalculateRotationFromNodeForces(Span span)
        {
            CalculateRotationFromMomentForces(span);
            CalculateRotationFromShearForces(span);
        }

        private void CalculateRotationFromContinousLoads(Span span)
        {
            foreach (var load in span.ContinousLoads)
            {
                if (_distanceFromLeftSide > load.EndPosition.Position + _currentLength)
                    CalculateRotationOutsideLoadLength(span, load);
                else if (_distanceFromLeftSide > load.StartPosition.Position + _currentLength)
                    CalculateRotationInsideLoadLength(span, load);
            }
        }

        private void CalculateRotationFromPointLoads(Span span)
        {
            foreach (var load in span.PointLoads)
            {
                if (_distanceFromLeftSide - _currentLength <= load.Position)
                    continue;

                _spanRotation += load.Value
                    * (_distanceFromLeftSide - _currentLength - load.Position)
                    * (_distanceFromLeftSide - _currentLength - load.Position) / 2
                    / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            }
        }

        private void CalculateRotationFromMomentForces(Span span)
        {
            _spanRotation += (span.LeftNode.BendingMoment?.Value * (_distanceFromLeftSide - _currentLength) ?? 0)
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            _spanRotation += span.LeftNode.ConcentratedForces.Where(cf => cf is BendingMoment).Sum(cf => cf.Value) *
                (_distanceFromLeftSide - _currentLength)
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }

        private void CalculateRotationFromShearForces(Span span)
        {
            _spanRotation += (span.LeftNode.ShearForce?.Value * (_distanceFromLeftSide - _currentLength) *
                (_distanceFromLeftSide - _currentLength) / 2 ?? 0)
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            _spanRotation += span.LeftNode.ConcentratedForces.Where(cf => cf is ShearLoad).Sum(cf => cf.Value) *
                (_distanceFromLeftSide - _currentLength) * (_distanceFromLeftSide - _currentLength) / 2
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }

        private void CalculateRotationOutsideLoadLength(Span span, Loads.ContinousLoads.ContinousLoad load)
        {
            double forceAtX = GetForceAtTheCalculatedPoint(load);

            _spanRotation += load.StartPosition.Value *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 2 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 3 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) * 3 / 4
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            _spanRotation += forceAtX *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 2 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 3 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 4
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);

            _spanRotation -= load.EndPosition.Value *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) / 2 *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) / 3 *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) * 3 / 4
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            _spanRotation -= forceAtX *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) / 2 *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) / 3 *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) / 4
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }

        private void CalculateRotationInsideLoadLength(Span span, Loads.ContinousLoads.ContinousLoad load)
        {
            double forceAtX = GetForceAtTheCalculatedPoint(load);

            _spanRotation += load.StartPosition.Value *
               (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 2 *
               (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 3 *
               (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) * 3 / 4
               / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            _spanRotation += forceAtX *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 2 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 3 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 4
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }

        private double GetForceAtTheCalculatedPoint(Loads.ContinousLoads.ContinousLoad load)
            => (load.EndPosition.Value - load.StartPosition.Value) /
                (load.EndPosition.Position - load.StartPosition.Position) *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) +
                load.StartPosition.Value;
    }
}
