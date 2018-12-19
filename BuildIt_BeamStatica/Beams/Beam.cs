using Build_IT_BeamStatica.Beams.Interfaces;
using Build_IT_BeamStatica.Loads.PointLoads;
using Build_IT_BeamStatica.Nodes;
using Build_IT_BeamStatica.Nodes.Interfaces;
using Build_IT_BeamStatica.Results.Interfaces;
using Build_IT_BeamStatica.Results.OnSpan;
using Build_IT_BeamStatica.Spans;
using Build_IT_BeamStatica.Spans.Interfaces;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_BeamStatica.Beams
{
    public class Beam : IBeam
    {
        public IGetResult NormalForceResult { get; }
        public IGetResult ShearResult { get; }
        public IGetResult BendingMomentResult { get; }
        public IGetResult HorizontalDeflectionResult { get; }
        public IGetResult VerticalDeflectionResult { get; }
        public IGetResult RotationResult { get; }

        public double Length => Spans.Sum(s => s.Length);

        public short NumberOfDegreesOfFreedom { get; private set; }

        public IList<ISpan> Spans { get; }
        public ICollection<INode> Nodes { get; }

        public IGlobalStiffnessMatrix GlobalStiffnessMatrix { get; }

        public Vector<double> JointLoadVector { get; private set; }
        public Vector<double> SpanLoadVector { get; private set; }

        public Vector<double> DeflectionVector { get; private set; }

        public Beam(IList<ISpan> spans, ICollection<INode> nodes)
        {
            Spans = spans ?? throw new ArgumentNullException(nameof(spans));
            Nodes = nodes ?? throw new ArgumentNullException(nameof(nodes));

            GlobalStiffnessMatrix = new GlobalStiffnessMatrix(this);
            NormalForceResult = new NormalForceResult(this);
            ShearResult = new ShearResult(this);
            BendingMomentResult = new BendingMomentResult(this);
            HorizontalDeflectionResult = new HorizontalDeflectionResult(this);
            VerticalDeflectionResult = new VerticalDeflectionResult(this);
            RotationResult = new RotationResult(this);
        }

        public void Calculate()
        {
            SetNumeration();
            CalculateStiffnessMatrixes();
            GlobalStiffnessMatrix.Calculate();
            CaluclateJointLoadVector();
            CalculateSpanLoadVectors();
            CalculateSpanLoadVector();
            CalculateDeflectionVector();
            CalculateDisplacements();
            CalculateForces();
            CalculateReactions();
            AddForcesLocatedAtSupports();
        }

        private void SetNumeration()
        {
            short spanCounter = 0;
            short nodeCounter = 0;

            spanCounter = SetSpanNumeration(spanCounter);
            nodeCounter = SetNodeNumeration(nodeCounter);

            SetNumberOfDegreesOfFreedom();
        }

        private void CalculateStiffnessMatrixes()
        {
            foreach (var span in Spans)
                span.StiffnessMatrix.Calculate();
        }

        private void CaluclateJointLoadVector()
        {
            if (NumberOfDegreesOfFreedom != 0)
                JointLoadVector = Vector<double>.Build.Dense(NumberOfDegreesOfFreedom);

            for (int i = 0; i < NumberOfDegreesOfFreedom; i++)
            {
                if (Nodes.Any(n => n.HorizontalMovementNumber == i))
                    JointLoadVector[i] = Nodes.SingleOrDefault(n => n.HorizontalMovementNumber == i)?
                       .ConcentratedForces.Sum(cf => cf.CalculateJointLoadVectorNormalForceMember()) ?? 0;
                else if (Nodes.Any(n => n.VerticalMovementNumber == i))
                    JointLoadVector[i] = Nodes.SingleOrDefault(n => n.VerticalMovementNumber == i)?
                        .ConcentratedForces.Sum(cf => cf.CalculateJointLoadVectorShearMember()) ?? 0;
                else
                    JointLoadVector[i] = Nodes.SingleOrDefault(n => n.LeftRotationNumber == i || n.RightRotationNumber == i)?
                        .ConcentratedForces.Sum(cf => cf.CalculateJointLoadVectorBendingMomentMember()) ?? 0;
            }
        }

        private void CalculateSpanLoadVectors()
        {
            foreach (var span in Spans)
                span.CalculateSpanLoadVector();
        }

        private void CalculateSpanLoadVector()
        {
            if (NumberOfDegreesOfFreedom != 0)
                SpanLoadVector = Vector<double>.Build.Dense(NumberOfDegreesOfFreedom);
            foreach (var span in Spans)
                CalculateSpanLoadVectorForCurrentSpan(span);
        }

        private void CalculateDeflectionVector()
        {
            if (NumberOfDegreesOfFreedom != 0)
                DeflectionVector = GlobalStiffnessMatrix.InversedMatrix * (JointLoadVector - SpanLoadVector);
        }

        private void CalculateDisplacements()
        {
            foreach (var span in Spans)
            {
                span.CalculateDisplacement(DeflectionVector, NumberOfDegreesOfFreedom);
                span.SetDisplacement();
            }
        }

        private void CalculateForces()
        {
            foreach (var span in Spans)
                span.CalculateForce();
        }

        private void CalculateReactions()
        {
            int numberOfReactions = Spans.Count * 3 + 3 - NumberOfDegreesOfFreedom;

            numberOfReactions += Nodes.Count(n => n is Hinge); // HACK: Check if needed

            for (int i = NumberOfDegreesOfFreedom; i < numberOfReactions + NumberOfDegreesOfFreedom; i++)
            {
                if (Spans.SingleOrDefault(s => s.LeftNode.HorizontalMovementNumber == i)?.LeftNode.NormalForce != null)
                    Spans.SingleOrDefault(s => s.LeftNode.HorizontalMovementNumber == i).LeftNode.NormalForce.Value
                        += Spans.Where(s => s.LeftNode.HorizontalMovementNumber == i).Sum(s => s.Forces[0]);

                if (Spans.SingleOrDefault(s => s.LeftNode.VerticalMovementNumber == i)?.LeftNode.ShearForce != null)
                    Spans.SingleOrDefault(s => s.LeftNode.VerticalMovementNumber == i).LeftNode.ShearForce.Value
                        += Spans.Where(s => s.LeftNode.VerticalMovementNumber == i).Sum(s => s.Forces[1]);

                if (Spans.SingleOrDefault(s => s.LeftNode.RightRotationNumber == i)?.LeftNode.BendingMoment != null)
                    Spans.SingleOrDefault(s => s.LeftNode.RightRotationNumber == i).LeftNode.BendingMoment.Value
                        -= Spans.Where(s => s.LeftNode.RightRotationNumber == i).Sum(s => s.Forces[2]);

                if (Spans.SingleOrDefault(s => s.RightNode.HorizontalMovementNumber == i)?.RightNode.NormalForce != null)
                    Spans.SingleOrDefault(s => s.RightNode.HorizontalMovementNumber == i).RightNode.NormalForce.Value
                        += Spans.Where(s => s.RightNode.HorizontalMovementNumber == i).Sum(s => s.Forces[3]);

                if (Spans.SingleOrDefault(s => s.RightNode.VerticalMovementNumber == i)?.RightNode.ShearForce != null)
                    Spans.SingleOrDefault(s => s.RightNode.VerticalMovementNumber == i).RightNode.ShearForce.Value
                        += Spans.Where(s => s.RightNode.VerticalMovementNumber == i).Sum(s => s.Forces[4]);

                if (Spans.SingleOrDefault(s => s.RightNode.LeftRotationNumber == i)?.RightNode.BendingMoment != null)
                    Spans.SingleOrDefault(s => s.RightNode.LeftRotationNumber == i).RightNode.BendingMoment.Value
                        -= Spans.Where(s => s.RightNode.LeftRotationNumber == i).Sum(s => s.Forces[5]);
            }
        }

        private void AddForcesLocatedAtSupports()
        {
            foreach (var node in Nodes)
            {
                if (node.NormalForce != null)
                    node.NormalForce.Value -= node.ConcentratedForces.Sum(cf => cf.CalculateNormalForce());
                if (node.ShearForce != null)
                    node.ShearForce.Value -= node.ConcentratedForces.Sum(cf => cf.CalculateShear());
                if (node.BendingMoment != null)
                    node.BendingMoment.Value -= node.ConcentratedForces.Sum(cf => cf.CalculateBendingMoment(0));
            }
        }

        private short SetSpanNumeration(short spanCounter)
        {
            foreach (var span in Spans)
                span.Number = spanCounter++;
            return spanCounter;
        }

        private short SetNodeNumeration(short nodeCounter)
        {
            foreach (var node in Nodes)
                node.SetDisplacementNumeration(ref nodeCounter);
            foreach (var node in Nodes)
                node.SetReactionNumeration(ref nodeCounter);
            return nodeCounter;
        }

        private void SetNumberOfDegreesOfFreedom()
        {
            foreach (var node in Nodes)
                NumberOfDegreesOfFreedom += node.DegreesOfFreedom;
        }

        private void CalculateSpanLoadVectorForCurrentSpan(ISpan span)
        {
            for (int i = 0; i < NumberOfDegreesOfFreedom; i++)
            {
                if (span.LeftNode.HorizontalMovementNumber == i)
                    SpanLoadVector[i] += span.LoadVector[0];
                else if (span.LeftNode.VerticalMovementNumber == i)
                    SpanLoadVector[i] += span.LoadVector[1];
                else if (span.LeftNode.RightRotationNumber == i)
                    SpanLoadVector[i] += span.LoadVector[2];
                else if(span.RightNode.HorizontalMovementNumber == i)
                    SpanLoadVector[i] += span.LoadVector[3];
                else if (span.RightNode.VerticalMovementNumber == i)
                    SpanLoadVector[i] += span.LoadVector[4];
                else if (span.RightNode.LeftRotationNumber == i)
                    SpanLoadVector[i] += span.LoadVector[5];
            }
        }
    }
}
