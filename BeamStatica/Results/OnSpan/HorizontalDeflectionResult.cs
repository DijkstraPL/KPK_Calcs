using BeamStatica.Beams;
using BeamStatica.Loads.PointLoads;
using BeamStatica.Nodes;
using BeamStatica.Results.Displacements;
using BeamStatica.Results.Interfaces;
using BeamStatica.Spans;
using BeamStatica.Spans.Interfaces;
using System;
using System.Linq;

namespace BeamStatica.Results.OnSpan
{
    class HorizontalDeflectionResult : IGetResult
    {
        private const double _nextToNodePosition = 0.00000001;

        public IResultValue Result { get; private set; }
        private double _currentLength;
        private double _distanceFromLeftSide;

        private double _spanDeflection;

        private readonly Beam _beam;

        public HorizontalDeflectionResult(Beam beam)
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

            _spanDeflection *= 1000;
            Result.Value -= _spanDeflection;

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
                    CalculateDeflectionFromPointLoads(span);
                }
                _currentLength += span.Length;
            }
        }

        private bool IsLastNode(ISpan span) =>
            span == _beam.Spans.Last() && _distanceFromLeftSide == _beam.Length;

        private void CalculateDeflectionFromCalculatedForcesAndDisplacements(ISpan span)
        {
            _spanDeflection += span.LeftNode.HorizontalDeflection?.Value / 100000 ?? 0;
            // _spanDeflection += span.LeftNode.RightRotation?.Value * (_distanceFromLeftSide - _currentLength) / 100 ?? 0;

            if (_currentLength != 0)
            {
                _spanDeflection += _beam.NormalForceResult.GetValue(_currentLength).Value
                    * (_distanceFromLeftSide - _currentLength)
                    / (span.Material.YoungModulus * span.Section.Area);
            }
        }

        private void CalculateDeflectionFromNodeForces(ISpan span)
        {
            CalculateDeflectionFromNormalForces(span);
        }

        private void CalculateDeflectionFromPointLoads(ISpan span)
        {
            foreach (var load in span.PointLoads.Where(pl => pl is NormalLoad))
            {
                if (_distanceFromLeftSide - _currentLength <= load.Position)
                    continue;

                _spanDeflection += load.Value
                    * (_distanceFromLeftSide - _currentLength - load.Position)
                    / (span.Material.YoungModulus * span.Section.Area);
            }
        }

        private void CalculateDeflectionFromNormalForces(ISpan span)
        {
            _spanDeflection += (span.LeftNode.NormalForce?.Value
                * (_distanceFromLeftSide - _currentLength)
                ?? 0)
                / (span.Material.YoungModulus * span.Section.Area);
            _spanDeflection += span.LeftNode.ConcentratedForces.Where(cf => cf is NormalLoad).Sum(cf => cf.Value)
                * (_distanceFromLeftSide - _currentLength)
                / (span.Material.YoungModulus * span.Section.Area);
        }
    }
}
