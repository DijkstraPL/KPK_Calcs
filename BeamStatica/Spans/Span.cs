using BeamStatica.Loads.ContinousLoads;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Materials.Intefaces;
using BeamStatica.Nodes;
using BeamStatica.Nodes.Interfaces;
using BeamStatica.Sections.Interfaces;
using BeamStatica.Spans.Interfaces;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace BeamStatica.Spans
{
    public class Span : ISpan
    {
        public short Number { get; set; }

        public INode LeftNode { get; }

        [Abbreviation("L")]
        [Unit("m")]
        public double Length { get; }

        public INode RightNode { get; }

        public IYoungModulus Material { get; }

        public ISection Section { get; }

        public ICollection<ContinousLoad> ContinousLoads { get; set; }
        public ICollection<ILoad> PointLoads { get; set; }

        public IStiffnessMatrix StiffnessMatrix { get; }
        public Vector<double> LoadVector { get; private set; }
        public Vector<double> Displacements { get; private set; }
        public Vector<double> Forces { get; private set; }

        public Span(INode leftNode, double length, INode rightNode, IYoungModulus material, ISection section)
        {
            LeftNode = leftNode ?? throw new ArgumentNullException(nameof(leftNode));
            Length = length;
            RightNode = rightNode ?? throw new ArgumentNullException(nameof(rightNode));
            Material = material ?? throw new ArgumentNullException(nameof(material));
            Section = section ?? throw new ArgumentNullException(nameof(section));

            ContinousLoads = new List<ContinousLoad>();
            PointLoads = new List<ILoad>();
            StiffnessMatrix = new StiffnessMatrix(this);
        }

        public void CalculateSpanLoadVector()
        {
            LoadVector = Vector<double>.Build.Dense(StiffnessMatrix.Size);

            LoadVector[0] = ContinousLoads.Sum(cl => CalculateNormalForce(cl, leftNode: true)) +
                PointLoads.Sum(pl => pl.CalculateSpanLoadVectorNormalForceMember(this.Length, leftNode: true));

            LoadVector[1] = ContinousLoads.Sum(cl => CalculateShear(cl, leftNode: true)) +
                PointLoads.Sum(pl => pl.CalculateSpanLoadVectorShearMember(this.Length, leftNode: true));

            LoadVector[2] = ContinousLoads.Sum(cl => CalculateBendingMoment(cl, leftNode: true)) +
                PointLoads.Sum(pl => pl.CalculateSpanLoadBendingMomentMember(this.Length, leftNode: true));

            LoadVector[3] = ContinousLoads.Sum(cl => CalculateNormalForce(cl, leftNode: false)) +
                PointLoads.Sum(pl => pl.CalculateSpanLoadVectorNormalForceMember(this.Length, leftNode: false));

            LoadVector[4] = ContinousLoads.Sum(cl => CalculateShear(cl, leftNode: false)) +
               PointLoads.Sum(pl => pl.CalculateSpanLoadVectorShearMember(this.Length, leftNode: false));

            LoadVector[5] = ContinousLoads.Sum(cl => CalculateBendingMoment(cl, leftNode: false)) +
                PointLoads.Sum(pl => pl.CalculateSpanLoadBendingMomentMember(this.Length, leftNode: false));
        }

        public void CalculateDisplacement(Vector<double> deflectionVector, int numberOfDegreesOfFreedom)
        {
            Displacements = Vector<double>.Build.Dense(StiffnessMatrix.Size);

            if(LeftNode.HorizontalMovementNumber < numberOfDegreesOfFreedom)
                Displacements[0] = deflectionVector[LeftNode.HorizontalMovementNumber];
            if (LeftNode.VerticalMovementNumber < numberOfDegreesOfFreedom)
                Displacements[1] = deflectionVector[LeftNode.VerticalMovementNumber];
            if (LeftNode.RightRotationNumber < numberOfDegreesOfFreedom)
                Displacements[2] = deflectionVector[LeftNode.RightRotationNumber];
            if (RightNode.HorizontalMovementNumber < numberOfDegreesOfFreedom)
                Displacements[3] = deflectionVector[RightNode.HorizontalMovementNumber];
            if (RightNode.VerticalMovementNumber < numberOfDegreesOfFreedom)
                Displacements[4] = deflectionVector[RightNode.VerticalMovementNumber];
            if (RightNode.LeftRotationNumber < numberOfDegreesOfFreedom)
                Displacements[5] = deflectionVector[RightNode.LeftRotationNumber];
        }
               
        public void SetDisplacement()
        {
            if (LeftNode.HorizontalDeflection != null)
                LeftNode.HorizontalDeflection.Value = Displacements[0] * 1000; // mm
            if (LeftNode.VerticalDeflection != null)
                LeftNode.VerticalDeflection.Value = Displacements[1] * 1000; // mm
            if (LeftNode.RightRotation != null)
                LeftNode.RightRotation.Value = Displacements[2];
            if (RightNode.HorizontalDeflection != null)
                RightNode.HorizontalDeflection.Value = Displacements[3] * 1000; // mm
            if (RightNode.VerticalDeflection != null)
                RightNode.VerticalDeflection.Value = Displacements[4] * 1000; // mm
            if (RightNode.LeftRotation != null)
                RightNode.LeftRotation.Value = Displacements[5];
        }

        public void CalculateForce()
        {
            Forces = StiffnessMatrix.Matrix.Multiply(Displacements).Add(LoadVector);
        }
        
        private double CalculateNormalForce(ContinousLoad cl, bool leftNode)
        {
           return 0;
        }

        private double CalculateShear(ContinousLoad continousLoad, bool leftNode)
        {
            double closerLoad = leftNode ? -continousLoad.StartPosition.Value : -continousLoad.EndPosition.Value;
            double furtherLoad = leftNode ? -continousLoad.EndPosition.Value : -continousLoad.StartPosition.Value;
            double distanceFromCalculatedNode = leftNode ? continousLoad.StartPosition.Position : Length - continousLoad.EndPosition.Position;
            double loadLength = continousLoad.EndPosition.Position - continousLoad.StartPosition.Position;
            double distanceToOtherNode = leftNode ? Length - continousLoad.EndPosition.Position : continousLoad.StartPosition.Position;

            return 1.0 / 20 * furtherLoad * loadLength *
                (3 * Math.Pow(loadLength, 3) +
                5 * Math.Pow(loadLength, 2) * distanceFromCalculatedNode +
                10 * Math.Pow(distanceToOtherNode, 3) +
                30 * Math.Pow(distanceToOtherNode, 2) * loadLength +
                30 * Math.Pow(distanceToOtherNode, 2) * distanceFromCalculatedNode +
                15 * Math.Pow(loadLength, 2) * distanceToOtherNode +
                20 * distanceFromCalculatedNode * loadLength * distanceToOtherNode) /
                Math.Pow(Length, 3) +
                1.0 / 20 * closerLoad * loadLength *
                (7 * Math.Pow(loadLength, 3) +
                15 * Math.Pow(loadLength, 2) * distanceFromCalculatedNode +
                10 * Math.Pow(distanceToOtherNode, 3) +
                 30 * Math.Pow(distanceToOtherNode, 2) * loadLength +
                 30 * Math.Pow(distanceToOtherNode, 2) * distanceFromCalculatedNode +
                 25 * Math.Pow(loadLength, 2) * distanceToOtherNode +
                 40 * distanceFromCalculatedNode * loadLength * distanceToOtherNode) /
                 Math.Pow(Length, 3);
        }

        private double CalculateBendingMoment(ContinousLoad continousLoad, bool leftNode)
        {
            double sign = leftNode ? 1.0 : -1.0;
            double closerLoad = leftNode ? -continousLoad.StartPosition.Value : -continousLoad.EndPosition.Value;
            double furtherLoad = leftNode ? -continousLoad.EndPosition.Value : -continousLoad.StartPosition.Value;
            double distanceFromCalculatedNode = leftNode ? continousLoad.StartPosition.Position : Length - continousLoad.EndPosition.Position;
            double loadLength = continousLoad.EndPosition.Position - continousLoad.StartPosition.Position;
            double distanceToOtherNode = leftNode ? Length - continousLoad.EndPosition.Position : continousLoad.StartPosition.Position;

            return sign / 60 * closerLoad * loadLength *
                   (3 * Math.Pow(loadLength, 3) +
                   15 * Math.Pow(loadLength, 2) * distanceFromCalculatedNode +
                   10 * Math.Pow(distanceToOtherNode, 2) * loadLength +
                   30 * Math.Pow(distanceToOtherNode, 2) * distanceFromCalculatedNode +
                   10 * Math.Pow(loadLength, 2) * distanceToOtherNode +
                   40 * distanceFromCalculatedNode * loadLength * distanceToOtherNode) /
                   Math.Pow(Length, 2) +
                   sign / 60 * furtherLoad * loadLength *
                   (2 * Math.Pow(loadLength, 3) +
                   5 * Math.Pow(loadLength, 2) * distanceFromCalculatedNode +
                   20 * Math.Pow(distanceToOtherNode, 2) * loadLength +
                   30 * Math.Pow(distanceToOtherNode, 2) * distanceFromCalculatedNode +
                   10 * Math.Pow(loadLength, 2) * distanceToOtherNode +
                   20 * distanceFromCalculatedNode * loadLength * distanceToOtherNode) /
                   Math.Pow(Length, 2);
        }
    }
}
