﻿using Build_IT_FrameStatica.Frames.Interfaces;
using Build_IT_FrameStatica.Results.Displacements;
using Build_IT_FrameStatica.Results.Interfaces;
using Build_IT_FrameStatica.Spans.Interfaces;
using System.Linq;

namespace Build_IT_FrameStatica.Results.OnSpan
{
    internal class HorizontalDeflectionResult : Result
    {
        #region Properties

        public IResultValue Result { get; private set; }

        #endregion // Properties

        #region Fields

        private const double _nextToNodePosition = 0.00000001;

        private double _currentLength;
        private double _distanceFromLeftSide;

        private double _spanDeflection;

        #endregion // Fields

        #region Constructors

        public HorizontalDeflectionResult(IFrame frame) : base(frame)
        {
        }

        #endregion // Constructors

        #region Protected_Methods

        protected override IResultValue CalculateAtPosition(ISpan span, double distanceFromLeftSide)
        {
            _distanceFromLeftSide = distanceFromLeftSide;
            Result = new Rotation(distanceFromLeftSide) { Value = 0 };

            _currentLength = 0;

            _spanDeflection = 0;

            CalculateDeflection(span);

            _spanDeflection *= 10;
            Result.Value += _spanDeflection;

            return Result;
        }

        #endregion // Protected_Methods

        #region Private_Methods

        private void CalculateDeflection(ISpan span)
        {
            double calculatedLength = 0;
            calculatedLength += span.Length;
            if (calculatedLength <= _distanceFromLeftSide &&
               !IsLastNode(span))
                _currentLength += span.Length;

            if (_distanceFromLeftSide >= _currentLength)
            {
                CalculateDeflectionFromCalculatedForcesAndDisplacements(span);
                CalculateDeflectionFromNodeForces(span);
                CalculateDeflectionFromContinousLoads(span);
                CalculateDeflectionFromPointLoads(span);
            }
            _currentLength += span.Length;

        }

        private bool IsLastNode(ISpan span) =>
            span == Frame.Spans.Last(); //&& _distanceFromLeftSide == Frame.Length;

        private void CalculateDeflectionFromCalculatedForcesAndDisplacements(ISpan span)
        {
            _spanDeflection += span.LeftNode.HorizontalDeflection?.Value / 10 ?? 0;

            if (_currentLength != 0)
            {
                _spanDeflection -= Frame.Results.NormalForce.GetValue(_currentLength, span.Number).Value
                    * (_distanceFromLeftSide - _currentLength)
                    / (span.Material.YoungModulus * span.Section.Area);
            }
        }

        private void CalculateDeflectionFromNodeForces(ISpan span)
        {
            CalculateDeflectionFromNormalForces(span);
        }

        private void CalculateDeflectionFromContinousLoads(ISpan span)
        {
            _spanDeflection -= span.ContinousLoads.Sum(cl =>
            cl.CalculateHorizontalDeflection(span, _distanceFromLeftSide, _currentLength));
        }

        private void CalculateDeflectionFromPointLoads(ISpan span)
        {
            CalculateDeflectionFromHorizontalDisplacements(span);
            CalculateDeflectionFromNormalForcesPointLoads(span);
        }

        private void CalculateDeflectionFromHorizontalDisplacements(ISpan span)
        {
            _spanDeflection += span.LeftNode.ConcentratedForces.Sum(cf
                => cf.CalculateHorizontalDisplacement()) / 10;
        }

        private void CalculateDeflectionFromNormalForcesPointLoads(ISpan span)
        {
            foreach (var load in span.PointLoads)
            {
                if (_distanceFromLeftSide - _currentLength <= load.Position)
                    continue;

                _spanDeflection -= load.CalculateNormalForce()
                    * (_distanceFromLeftSide - _currentLength - load.Position)
                    / (span.Material.YoungModulus * span.Section.Area);
            }
        }

        private void CalculateDeflectionFromNormalForces(ISpan span)
        {
            _spanDeflection -= (span.LeftNode.HorizontalForce?.Value
                * (_distanceFromLeftSide - _currentLength)
                ?? 0)
                / (span.Material.YoungModulus * span.Section.Area);
            _spanDeflection -= span.LeftNode.ConcentratedForces.Sum(cf => cf.CalculateNormalForce())
                * (_distanceFromLeftSide - _currentLength)
                / (span.Material.YoungModulus * span.Section.Area);
        }

        #endregion // Private_Methods
    }
}
