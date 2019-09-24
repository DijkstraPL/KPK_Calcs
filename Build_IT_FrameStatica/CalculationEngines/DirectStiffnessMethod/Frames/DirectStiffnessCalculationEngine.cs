using Build_IT_CommonTools.MatrixMath.Wrappers;
using Build_IT_FrameStatica.CalculationEngines.DirectStiffnessMethod.Frames.Interfaces;
using Build_IT_FrameStatica.CalculationEngines.DirectStiffnessMethod.Spans;
using Build_IT_FrameStatica.CalculationEngines.DirectStiffnessMethod.Spans.Interfaces;
using Build_IT_FrameStatica.CalculationEngines.Interfaces;
using Build_IT_FrameStatica.Frames;
using Build_IT_FrameStatica.Frames.Interfaces;
using Build_IT_FrameStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_FrameStatica.CalculationEngines.DirectStiffnessMethod.Frames
{
    internal class DirectStiffnessCalculationEngine : IFrameCalculationEngine
    {
        #region Fields
        
        private IFrame _frame;
        private IGlobalStiffnessMatrix _globalStiffnessMatrix;

        private IList<(ISpan span, ISpanCalculationEngine calculationEngine)> _spanCalculationEngines
            = new List<(ISpan, ISpanCalculationEngine)>();

        private VectorAdapter _jointLoadVector;
        private VectorAdapter _spanLoadVector;
        private VectorAdapter _deflectionVector;

        #endregion // Fields

        #region Constructors

        public DirectStiffnessCalculationEngine(IFrame frame, IGlobalStiffnessMatrix globalStiffnessMatrix = null)
        {
            _frame = frame;
            _globalStiffnessMatrix = globalStiffnessMatrix ?? new GlobalStiffnessMatrix(_frame, _spanCalculationEngines);

            SetSpanCalculationEngines();
        }

        #endregion // Constructors

        #region Public_Methods
        
        public void Calculate()
        {
            _frame.SetNumeration();
            CalculateStiffnessMatrixes();
            _globalStiffnessMatrix.Calculate();
            CaluclateJointLoadVector();
            CalculateSpanLoadVectors();
            CalculateSpanLoadVector();
            CalculateDeflectionVector();
            if (CheckDeflectionVector())
                throw new ArgumentException("Mechanism");
            CalculateDisplacements();
            CalculateForces();
            CalculateReactions();
        }

        #endregion // Public_Methods

        #region Private_Methods
        
        private void SetSpanCalculationEngines()
        {
            foreach (var span in _frame.Spans)
                _spanCalculationEngines.Add((span, new SpanCalculationEngine(span)));
        }


        private void CalculateStiffnessMatrixes()
        {
            foreach (var spanEnginePair in _spanCalculationEngines)
                spanEnginePair.calculationEngine.StiffnessMatrix.Calculate();
        }

        private void CaluclateJointLoadVector()
        {
            if (_frame.NumberOfDegreesOfFreedom != 0)
                _jointLoadVector = VectorAdapter.Create(_frame.NumberOfDegreesOfFreedom);

            for (int i = 0; i < _frame.NumberOfDegreesOfFreedom; i++)
            {
                if (_frame.Nodes.Any(n => n.HorizontalMovementNumber == i))
                    _jointLoadVector[i] = _frame.Nodes.SingleOrDefault(n => n.HorizontalMovementNumber == i)?
                       .ConcentratedForces.Sum(cf => cf.CalculateJointLoadVectorNormalForceMember()) ?? 0;
                else if (_frame.Nodes.Any(n => n.VerticalMovementNumber == i))
                    _jointLoadVector[i] = _frame.Nodes.SingleOrDefault(n => n.VerticalMovementNumber == i)?
                        .ConcentratedForces.Sum(cf => cf.CalculateJointLoadVectorShearMember()) ?? 0;
                else
                    _jointLoadVector[i] = _frame.Nodes.SingleOrDefault(n => n.LeftRotationNumber == i || n.RightRotationNumber == i)?
                        .ConcentratedForces.Sum(cf => cf.CalculateJointLoadVectorBendingMomentMember()) ?? 0;
            }
        }

        private void CalculateSpanLoadVectors()
        {
            foreach (var spanEnginePair in _spanCalculationEngines)
                spanEnginePair.calculationEngine.CalculateSpanLoadVector();
        }

        private void CalculateSpanLoadVector()
        {
            if (_frame.NumberOfDegreesOfFreedom != 0)
                _spanLoadVector = VectorAdapter.Create(_frame.NumberOfDegreesOfFreedom);
            foreach (var spanEnginePair in _spanCalculationEngines)
                CalculateSpanLoadVectorForCurrentSpan(spanEnginePair);
        }

        private void CalculateDeflectionVector()
        {
            if (_frame.NumberOfDegreesOfFreedom != 0)
                _deflectionVector = _globalStiffnessMatrix.InversedMatrix * (_jointLoadVector - _spanLoadVector);
        }

        private bool CheckDeflectionVector()
            => _deflectionVector != null && _deflectionVector.Any(dv => double.IsNaN(dv));

        private void CalculateDisplacements()
        {
            foreach (var spanEnginePair in _spanCalculationEngines)
                spanEnginePair.calculationEngine.CalculateDisplacement(_deflectionVector, _frame.NumberOfDegreesOfFreedom);
        }

        private void CalculateForces()
        {
            foreach (var spanEnginePair in _spanCalculationEngines)
                spanEnginePair.calculationEngine.CalculateForce(
                    spanEnginePair.calculationEngine.LoadVector,
                    spanEnginePair.calculationEngine.Displacements);
        }

        private void CalculateReactions()
        {
            int numberOfReactions = _frame.Spans.Count * 3 + 3 - _frame.NumberOfDegreesOfFreedom;

            //numberOfReactions += _frame.Nodes.Count(n => n is Hinge);

            for (int i = _frame.NumberOfDegreesOfFreedom; i < numberOfReactions + _frame.NumberOfDegreesOfFreedom; i++)
            {
                SetLeftNodeReactions(i);
                SetRightNodeReactions(i);
            }
        }

        private void SetLeftNodeReactions(int i)
        {
            if (_frame.Spans.SingleOrDefault(s => s.LeftNode.HorizontalMovementNumber == i)?.LeftNode.NormalForce != null)
                _frame.Spans.SingleOrDefault(s => s.LeftNode.HorizontalMovementNumber == i).LeftNode.NormalForce.Value
                    += _spanCalculationEngines.Where(sep => sep.span.LeftNode.HorizontalMovementNumber == i)
                    .Sum(sep => sep.calculationEngine.Forces[0]);

            if (_frame.Spans.SingleOrDefault(s => s.LeftNode.VerticalMovementNumber == i)?.LeftNode.ShearForce != null)
                _frame.Spans.SingleOrDefault(s => s.LeftNode.VerticalMovementNumber == i).LeftNode.ShearForce.Value
                    += _spanCalculationEngines.Where(sep => sep.span.LeftNode.VerticalMovementNumber == i)
                    .Sum(sep => sep.calculationEngine.Forces[1]);

            if (_frame.Spans.SingleOrDefault(s => s.LeftNode.RightRotationNumber == i)?.LeftNode.BendingMoment != null)
                _frame.Spans.SingleOrDefault(s => s.LeftNode.RightRotationNumber == i).LeftNode.BendingMoment.Value
                    -= _spanCalculationEngines.Where(sep => sep.span.LeftNode.RightRotationNumber == i)
                    .Sum(sep => sep.calculationEngine.Forces[2]);
        }

        private void SetRightNodeReactions(int i)
        {
            if (_frame.Spans.SingleOrDefault(s => s.RightNode.HorizontalMovementNumber == i)?.RightNode.NormalForce != null)
                _frame.Spans.SingleOrDefault(s => s.RightNode.HorizontalMovementNumber == i).RightNode.NormalForce.Value
                    += _spanCalculationEngines.Where(sep => sep.span.RightNode.HorizontalMovementNumber == i)
                    .Sum(sep => sep.calculationEngine.Forces[3]);

            if (_frame.Spans.SingleOrDefault(s => s.RightNode.VerticalMovementNumber == i)?.RightNode.ShearForce != null)
                _frame.Spans.SingleOrDefault(s => s.RightNode.VerticalMovementNumber == i).RightNode.ShearForce.Value
                    += _spanCalculationEngines.Where(sep => sep.span.RightNode.VerticalMovementNumber == i)
                    .Sum(sep => sep.calculationEngine.Forces[4]);

            if (_frame.Spans.SingleOrDefault(s => s.RightNode.LeftRotationNumber == i)?.RightNode.BendingMoment != null)
                _frame.Spans.SingleOrDefault(s => s.RightNode.LeftRotationNumber == i).RightNode.BendingMoment.Value
                    -= _spanCalculationEngines.Where(sep => sep.span.RightNode.LeftRotationNumber == i)
                    .Sum(sep => sep.calculationEngine.Forces[5]);
        }


        private void CalculateSpanLoadVectorForCurrentSpan
            ((ISpan span, ISpanCalculationEngine calculationEngine) spanEnginePair)
        {
            for (int i = 0; i < _frame.NumberOfDegreesOfFreedom; i++)
            {
                if (spanEnginePair.span.LeftNode.HorizontalMovementNumber == i)
                    _spanLoadVector[i] += spanEnginePair.calculationEngine.LoadVector[0];
                else if (spanEnginePair.span.LeftNode.VerticalMovementNumber == i)
                    _spanLoadVector[i] += spanEnginePair.calculationEngine.LoadVector[1];
                else if (spanEnginePair.span.LeftNode.RightRotationNumber == i)
                    _spanLoadVector[i] += spanEnginePair.calculationEngine.LoadVector[2];
                else if (spanEnginePair.span.RightNode.HorizontalMovementNumber == i)
                    _spanLoadVector[i] += spanEnginePair.calculationEngine.LoadVector[3];
                else if (spanEnginePair.span.RightNode.VerticalMovementNumber == i)
                    _spanLoadVector[i] += spanEnginePair.calculationEngine.LoadVector[4];
                else if (spanEnginePair.span.RightNode.LeftRotationNumber == i)
                    _spanLoadVector[i] += spanEnginePair.calculationEngine.LoadVector[5];
            }
        }

        #endregion // Private_Methods
    }

}
