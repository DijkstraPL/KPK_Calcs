﻿using BeamStatica.Beams;
using BeamStatica.Beams.Interfaces;
using BeamStatica.Loads.PointLoads;
using BeamStatica.Results.Displacements;
using BeamStatica.Results.Interfaces;
using BeamStatica.Spans.Interfaces;
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
        private readonly IBeam _beam;
        private readonly bool _adjustRotation;

        public RotationResult(IBeam beam)
        {
            _beam = beam ?? throw new ArgumentNullException(nameof(beam));
        }

        private RotationResult(IBeam beam, bool adjustRotation) : this(beam)
        {
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

        private bool IsLastNode(ISpan span) =>
            span == _beam.Spans.Last() && _distanceFromLeftSide == _beam.Length;

        private void CalculateRotationFromCalculatedForcesAndDisplacements(ISpan span)
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

        private void CalculateRotationFromNodeForces(ISpan span)
        {
            CalculateRotationFromMomentForces(span);
            CalculateRotationFromShearForces(span);
        }

        private void CalculateRotationFromContinousLoads(ISpan span)
        {
            _spanRotation += span.ContinousLoads.Sum(cl => 
            cl.CalculateRotation(span, _distanceFromLeftSide, _currentLength));
        }

        private void CalculateRotationFromPointLoads(ISpan span)
        {
            CalculateRotationFromRotationDisplacements(span);
            CalculateRotationFromShearForcesPointLoads(span);
            CalculateRotationFromBendingMomentPointLoads(span);
        }

        private void CalculateRotationFromRotationDisplacements(ISpan span)
        {
            _spanRotation += span.LeftNode.ConcentratedForces.Sum(cf
                => cf.CalculateRotationDisplacement()) / 100;
        }

        private void CalculateRotationFromShearForcesPointLoads(ISpan span)
        {
            foreach (var load in span.PointLoads)
            {
                if (_distanceFromLeftSide - _currentLength <= load.Position)
                    continue;

                _spanRotation += load.CalculateShear()
                    * (_distanceFromLeftSide - _currentLength - load.Position)
                    * (_distanceFromLeftSide - _currentLength - load.Position) / 2
                    / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            }
        }

        private void CalculateRotationFromBendingMomentPointLoads(ISpan span)
        {
            foreach (var load in span.PointLoads)
            {
                if (_distanceFromLeftSide - _currentLength <= load.Position)
                    continue;

                _spanRotation += load.CalculateBendingMoment(0)
                    * (_distanceFromLeftSide - _currentLength - load.Position)
                    / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            }
        }

        private void CalculateRotationFromMomentForces(ISpan span)
        {
            _spanRotation += (span.LeftNode.BendingMoment?.Value * (_distanceFromLeftSide - _currentLength) ?? 0)
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            _spanRotation += span.LeftNode.ConcentratedForces.Sum(cf => cf.CalculateBendingMoment(0)) *
                (_distanceFromLeftSide - _currentLength)
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }

        private void CalculateRotationFromShearForces(ISpan span)
        {
            _spanRotation += (span.LeftNode.ShearForce?.Value * (_distanceFromLeftSide - _currentLength) *
                (_distanceFromLeftSide - _currentLength) / 2 ?? 0)
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
            _spanRotation += span.LeftNode.ConcentratedForces.Sum(cf => cf.CalculateShear()) *
                (_distanceFromLeftSide - _currentLength) * (_distanceFromLeftSide - _currentLength) / 2
                / (span.Material.YoungModulus * span.Section.MomentOfInteria);
        }
    }
}
