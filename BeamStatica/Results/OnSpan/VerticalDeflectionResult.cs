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
using BeamStatica.Loads.ContinousLoads;
using BeamStatica.Beams.Interfaces;

namespace BeamStatica.Results.OnSpan
{
    public class VerticalDeflectionResult : IGetResult
    {
        private const double _nextToNodePosition = 0.00000001;

        public IResultValue Result { get; private set; }
        private double _currentLength;
        private double _distanceFromLeftSide;

        private double _spanDeflection;

        private readonly IBeam _beam;

        public VerticalDeflectionResult(IBeam beam)
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
            _spanDeflection += span.ContinousLoads.Sum(cl =>
            cl.CalculateVerticalDeflection(span, _distanceFromLeftSide, _currentLength));
        }

        private void CalculateDeflectionFromPointLoads(ISpan span)
        {
            CalculateRotationFromRotationDisplacements(span);
            CalculateDeflectionFromVerticalDisplacements(span);
            CalculateDeflectionFromShearForcesPointLoads(span);
            CalculateDeflectionFromBendingMomentPointLoads(span);
        }

        private void CalculateDeflectionFromShearForcesPointLoads(ISpan span)
        {
            foreach (var load in span.PointLoads)
            {
                if (_distanceFromLeftSide - _currentLength <= load.Position)
                    continue;

                _spanDeflection += load.CalculateShear()
                    * (_distanceFromLeftSide - _currentLength - load.Position)
                    * (_distanceFromLeftSide - _currentLength - load.Position) / 2
                    * (_distanceFromLeftSide - _currentLength - load.Position) / 3
                    / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            }
        }

        private void CalculateDeflectionFromBendingMomentPointLoads(ISpan span)
        {
            foreach (var load in span.PointLoads)
            {
                if (_distanceFromLeftSide - _currentLength <= load.Position)
                    continue;

                _spanDeflection += load.CalculateBendingMoment(0)
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
            _spanDeflection += span.LeftNode.ConcentratedForces.Sum(cf => cf.CalculateShear())
                * (_distanceFromLeftSide - _currentLength)
                * (_distanceFromLeftSide - _currentLength) / 2
                * (_distanceFromLeftSide - _currentLength) / 3
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }

        private void CalculateRotationFromRotationDisplacements(ISpan span)
        {
            _spanDeflection += span.LeftNode.ConcentratedForces.Sum(cf
                => cf.CalculateRotationDisplacement()) * (_distanceFromLeftSide - _currentLength) / 100;
        }

        private void CalculateDeflectionFromVerticalDisplacements(ISpan span)
        {
            _spanDeflection += span.LeftNode.ConcentratedForces.Sum(cf 
                => cf.CalculateVerticalDisplacement()) / 100000;
        }

        private void CalculateDeflectionFromMomentForces(ISpan span)
        {
            _spanDeflection += (span.LeftNode.BendingMoment?.Value
                * (_distanceFromLeftSide - _currentLength)
                * (_distanceFromLeftSide - _currentLength) / 2 ?? 0)
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            _spanDeflection += span.LeftNode.ConcentratedForces.Sum(cf => cf.CalculateBendingMoment(0)) *
                (_distanceFromLeftSide - _currentLength) *
                (_distanceFromLeftSide - _currentLength) / 2
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }


        private double GetForceAtTheCalculatedPoint(IContinousLoad load)
            => (load.EndPosition.Value - load.StartPosition.Value) /
                (load.EndPosition.Position - load.StartPosition.Position) *
                (_distanceFromLeftSide - _currentLength - load.StartPosition.Position) +
                load.StartPosition.Value;
    }
}
