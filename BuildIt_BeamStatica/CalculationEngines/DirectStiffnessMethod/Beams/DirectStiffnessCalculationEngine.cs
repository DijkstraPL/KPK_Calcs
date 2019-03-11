using Build_IT_BeamStatica.Beams.Interfaces;
using Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Beams.Interfaces;
using Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Spans;
using Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Spans.Interfaces;
using Build_IT_BeamStatica.Nodes;
using Build_IT_BeamStatica.Spans.Interfaces;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Beams
{
    public class DirectStiffnessCalculationEngine : IDirectStiffnessCalculationEngine
    {
        #region Properties
        
        public IBeam Beam { get; }
        public IGlobalStiffnessMatrix GlobalStiffnessMatrix { get; }

        public Vector<double> JointLoadVector { get; private set; }
        public Vector<double> SpanLoadVector { get; private set; }
        public Vector<double> DeflectionVector { get; private set; }
        
        #endregion // Properties

        #region Fields

        private IList<(ISpan span, ISpanCalculationEngine calculationEngine)> _spanCalculationEngines
            = new List<(ISpan, ISpanCalculationEngine)>();

        #endregion // Fields

        #region Constructor

        public DirectStiffnessCalculationEngine(IBeam beam, IGlobalStiffnessMatrix globalStiffnessMatrix = null)
        {
            Beam = beam ?? throw new ArgumentNullException();
            GlobalStiffnessMatrix = globalStiffnessMatrix ?? new GlobalStiffnessMatrix(Beam, _spanCalculationEngines);

            SetSpanCalculationEngines();
        }

        #endregion // Constructor

        #region Public_Methods

        public void Calculate()
        {
            Beam.SetNumeration();
            CalculateStiffnessMatrixes();
            GlobalStiffnessMatrix.Calculate();
            if (Beam.IncludeSelfWeight)
                AddSelfWeightLoad();
            CaluclateJointLoadVector();
            CalculateSpanLoadVectors();
            CalculateSpanLoadVector();
            CalculateDeflectionVector();
            CalculateDisplacements();
            CalculateForces();
            CalculateReactions();
            AddForcesLocatedAtSupports();
        }

        #endregion // Public_Methods

        #region Private_Methods
        
        private void SetSpanCalculationEngines()
        {
            foreach (var span in Beam.Spans)
                _spanCalculationEngines.Add((span, new SpanCalculationEngine(span)));
        }

        private void AddSelfWeightLoad()
        {
            foreach (var span in Beam.Spans)
                span.IncludeSelfWeight = true;
        }

        private void CalculateStiffnessMatrixes()
        {
            foreach (var spanEnginePair in _spanCalculationEngines)
                spanEnginePair.calculationEngine.StiffnessMatrix.Calculate();
        }

        private void CaluclateJointLoadVector()
        {
            if (Beam.NumberOfDegreesOfFreedom != 0)
                JointLoadVector = Vector<double>.Build.Dense(Beam.NumberOfDegreesOfFreedom);

            for (int i = 0; i < Beam.NumberOfDegreesOfFreedom; i++)
            {
                if (Beam.Nodes.Any(n => n.HorizontalMovementNumber == i))
                    JointLoadVector[i] = Beam.Nodes.SingleOrDefault(n => n.HorizontalMovementNumber == i)?
                       .ConcentratedForces.Sum(cf => cf.CalculateJointLoadVectorNormalForceMember()) ?? 0;
                else if (Beam.Nodes.Any(n => n.VerticalMovementNumber == i))
                    JointLoadVector[i] = Beam.Nodes.SingleOrDefault(n => n.VerticalMovementNumber == i)?
                        .ConcentratedForces.Sum(cf => cf.CalculateJointLoadVectorShearMember()) ?? 0;
                else
                    JointLoadVector[i] = Beam.Nodes.SingleOrDefault(n => n.LeftRotationNumber == i || n.RightRotationNumber == i)?
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
            if (Beam.NumberOfDegreesOfFreedom != 0)
                SpanLoadVector = Vector<double>.Build.Dense(Beam.NumberOfDegreesOfFreedom);
            foreach (var spanEnginePair in _spanCalculationEngines)
                CalculateSpanLoadVectorForCurrentSpan(spanEnginePair);
        }
        
        private void CalculateDeflectionVector()
        {
            if (Beam.NumberOfDegreesOfFreedom != 0)
                DeflectionVector = GlobalStiffnessMatrix.InversedMatrix * (JointLoadVector - SpanLoadVector);
        }

        private void CalculateDisplacements()
        {
            foreach (var spanEnginePair in _spanCalculationEngines)
                spanEnginePair.calculationEngine.CalculateDisplacement(DeflectionVector, Beam.NumberOfDegreesOfFreedom);
        }

        private void CalculateForces()
        {
            foreach (var spanEnginePair in _spanCalculationEngines)
                spanEnginePair.calculationEngine.CalculateForce();
        }

        private void CalculateReactions()
        {
            int numberOfReactions = Beam.Spans.Count * 3 + 3 - Beam.NumberOfDegreesOfFreedom;

            numberOfReactions += Beam.Nodes.Count(n => n is Hinge); // HACK: Check if needed

            for (int i = Beam.NumberOfDegreesOfFreedom; i < numberOfReactions + Beam.NumberOfDegreesOfFreedom; i++)
            {
                SetLeftNodeReactions(i);
                SetRightNodeReactions(i);
            }
        }

        private void SetLeftNodeReactions(int i)
        {
            if (Beam.Spans.SingleOrDefault(s => s.LeftNode.HorizontalMovementNumber == i)?.LeftNode.NormalForce != null)
                Beam.Spans.SingleOrDefault(s => s.LeftNode.HorizontalMovementNumber == i).LeftNode.NormalForce.Value
                    += _spanCalculationEngines.Where(sep => sep.span.LeftNode.HorizontalMovementNumber == i)
                    .Sum(sep => sep.calculationEngine.Forces[0]);

            if (Beam.Spans.SingleOrDefault(s => s.LeftNode.VerticalMovementNumber == i)?.LeftNode.ShearForce != null)
                Beam.Spans.SingleOrDefault(s => s.LeftNode.VerticalMovementNumber == i).LeftNode.ShearForce.Value
                    += _spanCalculationEngines.Where(sep => sep.span.LeftNode.VerticalMovementNumber == i)
                    .Sum(sep => sep.calculationEngine.Forces[1]);

            if (Beam.Spans.SingleOrDefault(s => s.LeftNode.RightRotationNumber == i)?.LeftNode.BendingMoment != null)
                Beam.Spans.SingleOrDefault(s => s.LeftNode.RightRotationNumber == i).LeftNode.BendingMoment.Value
                    -= _spanCalculationEngines.Where(sep => sep.span.LeftNode.RightRotationNumber == i)
                    .Sum(sep => sep.calculationEngine.Forces[2]);
        }

        private void SetRightNodeReactions(int i)
        {
            if (Beam.Spans.SingleOrDefault(s => s.RightNode.HorizontalMovementNumber == i)?.RightNode.NormalForce != null)
                Beam.Spans.SingleOrDefault(s => s.RightNode.HorizontalMovementNumber == i).RightNode.NormalForce.Value
                    += _spanCalculationEngines.Where(sep => sep.span.RightNode.HorizontalMovementNumber == i)
                    .Sum(sep => sep.calculationEngine.Forces[3]);

            if (Beam.Spans.SingleOrDefault(s => s.RightNode.VerticalMovementNumber == i)?.RightNode.ShearForce != null)
                Beam.Spans.SingleOrDefault(s => s.RightNode.VerticalMovementNumber == i).RightNode.ShearForce.Value
                    += _spanCalculationEngines.Where(sep => sep.span.RightNode.VerticalMovementNumber == i)
                    .Sum(sep => sep.calculationEngine.Forces[4]);

            if (Beam.Spans.SingleOrDefault(s => s.RightNode.LeftRotationNumber == i)?.RightNode.BendingMoment != null)
                Beam.Spans.SingleOrDefault(s => s.RightNode.LeftRotationNumber == i).RightNode.BendingMoment.Value
                    -= _spanCalculationEngines.Where(sep => sep.span.RightNode.LeftRotationNumber == i)
                    .Sum(sep => sep.calculationEngine.Forces[5]);
        }

        private void AddForcesLocatedAtSupports()
        {
            foreach (var node in Beam.Nodes)
            {
                if (node.NormalForce != null)
                    node.NormalForce.Value -= node.ConcentratedForces.Sum(cf => cf.CalculateNormalForce());
                if (node.ShearForce != null)
                    node.ShearForce.Value -= node.ConcentratedForces.Sum(cf => cf.CalculateShear());
                if (node.BendingMoment != null)
                    node.BendingMoment.Value -= node.ConcentratedForces.Sum(cf => cf.CalculateBendingMoment(0));
            }
        }

        private void CalculateSpanLoadVectorForCurrentSpan((ISpan span, ISpanCalculationEngine calculationEngine) spanEnginePair)
        {
            for (int i = 0; i < Beam.NumberOfDegreesOfFreedom; i++)
            {
                if (spanEnginePair.span.LeftNode.HorizontalMovementNumber == i)
                    SpanLoadVector[i] += spanEnginePair.calculationEngine.LoadVector[0];
                else if (spanEnginePair.span.LeftNode.VerticalMovementNumber == i)
                    SpanLoadVector[i] += spanEnginePair.calculationEngine.LoadVector[1];
                else if (spanEnginePair.span.LeftNode.RightRotationNumber == i)
                    SpanLoadVector[i] += spanEnginePair.calculationEngine.LoadVector[2];
                else if (spanEnginePair.span.RightNode.HorizontalMovementNumber == i)
                    SpanLoadVector[i] += spanEnginePair.calculationEngine.LoadVector[3];
                else if (spanEnginePair.span.RightNode.VerticalMovementNumber == i)
                    SpanLoadVector[i] += spanEnginePair.calculationEngine.LoadVector[4];
                else if (spanEnginePair.span.RightNode.LeftRotationNumber == i)
                    SpanLoadVector[i] += spanEnginePair.calculationEngine.LoadVector[5];
            }
        }

        #endregion // Private_Methods
    }
}
