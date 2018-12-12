using BeamStatica.Loads.PointLoads;
using BeamStatica.Nodes;
using BeamStatica.Results.Displacements;
using BeamStatica.Results.Interfaces;
using BeamStatica.Spans;
using BeamStatica;
using System;
using System.Linq;
using BeamStatica.Beams;
using BeamStatica.Spans.Interfaces;
using BeamStatica.Loads.Interfaces;

namespace BeamStatica.Results.OnSpan
{
    class VerticalDeflectionResult : IGetResult
    {
        private const double _nextToNodePosition = 0.00000001;

        public IResultValue Result { get; private set; }
        private double _currentLength;
        private double _distanceFromLeftSide;

        private double _spanDeflection;

        private readonly Beam _beam;

        public VerticalDeflectionResult(Beam beam)
        {
            _beam = beam ?? throw new ArgumentNullException(nameof(beam));
        }

        public IResultValue GetValue(double distanceFromLeftSide)
        {
            _distanceFromLeftSide = distanceFromLeftSide;
            Result = new Rotation() { Value = 0 };

            _currentLength = 0;

            _spanDeflection = 0;

            CalculateDeflection();

            _spanDeflection *= 100000;
            Result.Value += _spanDeflection;

            return Result;
        }

        private void CalculateDeflection()
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

                if (_distanceFromLeftSide >= _currentLength)
                {
                    CalculateDeflectionFromCalculatedForcesAndDisplacements(span);
                    CalculateDeflectionFromNodeForces(span);
                    CalculateDeflectionFromContinousLoads(span);
                    CalculateDeflectionFromPointLoads(span);
                }
                _currentLength += span.Length;
            }
        }
        
        private bool IsLastNode(ISpan span) =>
            span == _beam.Spans.Last() && _distanceFromLeftSide == _beam.Length;

        private void CalculateDeflectionFromCalculatedForcesAndDisplacements(ISpan span)
        {
            _spanDeflection += span.LeftNode.VerticalDeflection?.Value / 100000 ?? 0;
            _spanDeflection += span.LeftNode.RightRotation?.Value * (_distanceFromLeftSide - _currentLength) / 100 ?? 0;

            if (_currentLength != 0)
            {
                _spanDeflection += _beam.ShearResult.GetValue(_currentLength).Value
                    * (_distanceFromLeftSide - _currentLength)
                    * (_distanceFromLeftSide - _currentLength) / 2
                    * (_distanceFromLeftSide - _currentLength) / 3
                    / (span.Material.YoungModulus * span.Section.MomentOfInteria);

                _spanDeflection += _beam.BendingMomentResult.GetValue(_currentLength).Value
                    * (_distanceFromLeftSide - _currentLength)
                    * (_distanceFromLeftSide - _currentLength) / 2
                    / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            }
        }

        private void CalculateDeflectionFromNodeForces(ISpan span)
        {
            CalculateDeflectionFromMomentForces(span);
            CalculateDeflectionFromShearForces(span);
        }

        private void CalculateDeflectionFromContinousLoads(ISpan span)
        {
            foreach (var load in span.ContinousLoads)
            {
                if (_distanceFromLeftSide > load.EndPosition.Position + _currentLength)
                    CalculateDeflectionOutsideLoadLength(span, load);
                else if (_distanceFromLeftSide > load.StartPosition.Position + _currentLength)
                    CalculateDeflectionInsideLoadLength(span, load);
            }
        }

        private void CalculateDeflectionFromPointLoads(ISpan span)
        {
            CalculateDeflectionFromVerticalDisplacements(span);
            CalculateDeflectionFromShearForcesPointLoads(span);
            CalculateDeflectionFromBendingMomentPointLoads(span);
        }

        private void CalculateDeflectionFromShearForcesPointLoads(ISpan span)
        {
            foreach (var load in span.PointLoads.Where(pl => pl is ShearLoad))
            {
                if (_distanceFromLeftSide - _currentLength <= load.Position)
                    continue;

                _spanDeflection += load.Value
                    * (_distanceFromLeftSide - _currentLength - load.Position)
                    * (_distanceFromLeftSide - _currentLength - load.Position) / 2
                    * (_distanceFromLeftSide - _currentLength - load.Position) / 3
                    / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            }
        }

        private void CalculateDeflectionFromBendingMomentPointLoads(ISpan span)
        {
            foreach (var load in span.PointLoads.Where(pl => pl is BendingMoment))
            {
                if (_distanceFromLeftSide - _currentLength <= load.Position)
                    continue;

                _spanDeflection += load.Value
                    * (_distanceFromLeftSide - _currentLength - load.Position)
                    * (_distanceFromLeftSide - _currentLength - load.Position) / 2
                    / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            }
        }

        private void CalculateDeflectionFromShearForces(ISpan span)
        {
            _spanDeflection += (span.LeftNode.ShearForce?.Value
                * (_distanceFromLeftSide - _currentLength)
                * (_distanceFromLeftSide - _currentLength) / 2
                * (_distanceFromLeftSide - _currentLength) / 3
                ?? 0)
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            _spanDeflection += span.LeftNode.ConcentratedForces.Where(cf => cf is ShearLoad).Sum(cf => cf.Value)
                * (_distanceFromLeftSide - _currentLength)
                * (_distanceFromLeftSide - _currentLength) / 2
                * (_distanceFromLeftSide - _currentLength) / 3
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }

        private void CalculateDeflectionFromVerticalDisplacements(ISpan span)
        {
            _spanDeflection += span.LeftNode.ConcentratedForces
                .Where(cf => cf is VerticalDisplacement).Sum(cf => cf.Value) / 100000;
        }

        private void CalculateDeflectionFromMomentForces(ISpan span)
        {
            _spanDeflection += (span.LeftNode.BendingMoment?.Value
                * (_distanceFromLeftSide - _currentLength)
                * (_distanceFromLeftSide - _currentLength) / 2 ?? 0)
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            _spanDeflection += span.LeftNode.ConcentratedForces.Where(cf => cf is BendingMoment).Sum(cf => cf.Value) *
                (_distanceFromLeftSide - _currentLength) *
                (_distanceFromLeftSide - _currentLength) / 2
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }

        private void CalculateDeflectionOutsideLoadLength(ISpan span, IContinousLoad load)
        {
            double forceAtX = GetForceAtTheCalculatedPoint(load);

            _spanDeflection += load.StartPosition.Value *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 2 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 3 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 4 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) * 4 / 5
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            _spanDeflection += forceAtX *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 2 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 3 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 4 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 5
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);

            _spanDeflection -= load.EndPosition.Value *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) / 2 *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) / 3 *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) / 4 *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) * 4 / 5
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            _spanDeflection -= forceAtX *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) / 2 *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) / 3 *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) / 4 *
                (_distanceFromLeftSide - _currentLength - load.EndPosition.Position) / 5
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }

        private void CalculateDeflectionInsideLoadLength(ISpan span, IContinousLoad load)
        {
            double forceAtX = GetForceAtTheCalculatedPoint(load);

            _spanDeflection += load.StartPosition.Value *
               (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 2 *
               (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 3 *
               (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 4 *
               (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) * 4 / 5
               / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            _spanDeflection += forceAtX *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 2 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 3 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 4 *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) / 5
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }

        private double GetForceAtTheCalculatedPoint(IContinousLoad load)
            => (load.EndPosition.Value - load.StartPosition.Value) /
                (load.EndPosition.Position - load.StartPosition.Position) *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) +
                load.StartPosition.Value;
    }
}
