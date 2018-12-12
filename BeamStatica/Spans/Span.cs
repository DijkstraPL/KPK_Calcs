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

        public ICollection<IContinousLoad> ContinousLoads { get; set; }
        public ICollection<ISpanLoad> PointLoads { get; set; }

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

            ContinousLoads = new List<IContinousLoad>();
            PointLoads = new List<ISpanLoad>();
            StiffnessMatrix = new StiffnessMatrix(this);
        }

        public void CalculateSpanLoadVector()
        {
            LoadVector = Vector<double>.Build.Dense(StiffnessMatrix.Size);

            LoadVector[0] = ContinousLoads.Sum(cl => cl.CalculateSpanLoadVectorNormalForceMember(this, leftNode: true)) +
                PointLoads.Sum(pl => pl.CalculateSpanLoadVectorNormalForceMember(this, leftNode: true)) +
                LeftNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadVectorNormalForceMember(this, leftNode: true) ?? 0) +
                RightNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadVectorNormalForceMember(this, leftNode: true) ?? 0);

            LoadVector[1] = ContinousLoads.Sum(cl => cl.CalculateSpanLoadVectorShearMember(this, leftNode: true)) +
                PointLoads.Sum(pl => pl.CalculateSpanLoadVectorShearMember(this, leftNode: true)) +
                LeftNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadVectorShearMember(this, leftNode: true) ?? 0) +
                RightNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadVectorShearMember(this, leftNode: true) ?? 0);

            LoadVector[2] = ContinousLoads.Sum(cl => cl.CalculateSpanLoadBendingMomentMember(this, leftNode: true)) +
                PointLoads.Sum(pl => pl.CalculateSpanLoadBendingMomentMember(this, leftNode: true)) +
                LeftNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadBendingMomentMember(this, leftNode: true) ?? 0) +
                RightNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadBendingMomentMember(this, leftNode: true) ?? 0);

            LoadVector[3] = ContinousLoads.Sum(cl => cl.CalculateSpanLoadVectorNormalForceMember(this, leftNode: false)) +
                PointLoads.Sum(pl => pl.CalculateSpanLoadVectorNormalForceMember(this, leftNode: false)) +
                LeftNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadVectorNormalForceMember(this, leftNode: false) ?? 0) +
                RightNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadVectorNormalForceMember(this, leftNode: false) ?? 0);

            LoadVector[4] = ContinousLoads.Sum(cl => cl.CalculateSpanLoadVectorShearMember(this, leftNode: false)) +
               PointLoads.Sum(pl => pl.CalculateSpanLoadVectorShearMember(this, leftNode: false)) +
                LeftNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadVectorShearMember(this, leftNode: false) ?? 0) +
                RightNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadVectorShearMember(this, leftNode: false) ?? 0);

            LoadVector[5] = ContinousLoads.Sum(cl => cl.CalculateSpanLoadBendingMomentMember(this, leftNode: false)) +
                PointLoads.Sum(pl => pl.CalculateSpanLoadBendingMomentMember(this, leftNode: false)) +
                LeftNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadBendingMomentMember(this, leftNode: false) ?? 0) +
                RightNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadBendingMomentMember(this, leftNode: false) ?? 0);
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
                LeftNode.HorizontalDeflection.Value = Displacements[0] * 100000; // mm
            if (LeftNode.VerticalDeflection != null)
                LeftNode.VerticalDeflection.Value = Displacements[1] * 1000; // mm
            if (LeftNode.RightRotation != null)
                LeftNode.RightRotation.Value = Displacements[2];
            if (RightNode.HorizontalDeflection != null)
                RightNode.HorizontalDeflection.Value = Displacements[3] * 100000; // mm
            if (RightNode.VerticalDeflection != null)
                RightNode.VerticalDeflection.Value = Displacements[4] * 1000; // mm
            if (RightNode.LeftRotation != null)
                RightNode.LeftRotation.Value = Displacements[5];
        }

        public void CalculateForce()
        {
            Forces = StiffnessMatrix.Matrix.Multiply(Displacements).Add(LoadVector);
        }      
    }
}
