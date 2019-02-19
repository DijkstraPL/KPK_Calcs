using Build_IT_BeamStatica.Loads.ContinousLoads;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Materials.Intefaces;
using Build_IT_BeamStatica.Nodes.Interfaces;
using Build_IT_BeamStatica.Sections.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;
using Build_IT_Tools;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_BeamStatica.Spans
{
    internal class Span : ISpan
    {
        #region Properties

        public short Number { get; set; }

        public INode LeftNode { get; }

        [Abbreviation("L")]
        [Unit("m")]
        public double Length { get; }

        public INode RightNode { get; }

        public IMaterial Material { get; }

        public ISection Section { get; }

        public ICollection<IContinousLoad> ContinousLoads { get; private set; }
        public ICollection<ISpanLoad> PointLoads { get; private set; }

        public IStiffnessMatrix StiffnessMatrix { get; }
        public Vector<double> LoadVector { get; private set; }
        public Vector<double> Displacements { get; private set; }
        public Vector<double> Forces { get; private set; }

        public bool IncludeSelfWeight { get; set; }

        #endregion // Properties

        #region Fields

        private const double g = 9.812;

        #endregion // Fields

        #region Constructors
        
        public Span(INode leftNode, double length, INode rightNode, 
            IMaterial material, ISection section, bool includeSelfWeight)
        {
            LeftNode = leftNode ?? throw new ArgumentNullException(nameof(leftNode));
            Length = length;
            RightNode = rightNode ?? throw new ArgumentNullException(nameof(rightNode));
            Material = material ?? throw new ArgumentNullException(nameof(material));
            Section = section ?? throw new ArgumentNullException(nameof(section));

            ContinousLoads = new List<IContinousLoad>();
            PointLoads = new List<ISpanLoad>();
            StiffnessMatrix = new StiffnessMatrix(this);

            IncludeSelfWeight = includeSelfWeight;
        }

        #endregion // Constructors

        #region Public_Methods

        public void CalculateSpanLoadVector()
        {
            if (IncludeSelfWeight)
                AddSelfWeightLoad();

            LoadVector = Vector<double>.Build.Dense(StiffnessMatrix.Size);

            LoadVector[0] = SetNormalForceLoadVector(isLeftNode: true);
            LoadVector[1] = SetShearForceLoadVector(isLeftNode: true);
            LoadVector[2] = SetBendingMomentForceLoadVector(isLeftNode: true);

            LoadVector[3] = SetNormalForceLoadVector(isLeftNode: false);
            LoadVector[4] = SetShearForceLoadVector(isLeftNode: false);
            LoadVector[5] = SetBendingMomentForceLoadVector(isLeftNode: false);
        }
        
        public void CalculateDisplacement(Vector<double> deflectionVector, int numberOfDegreesOfFreedom)
        {
            Displacements = Vector<double>.Build.Dense(StiffnessMatrix.Size);

            if (LeftNode.HorizontalMovementNumber < numberOfDegreesOfFreedom)
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

        #endregion // Public_Methods

        #region Private_Methods

        private void AddSelfWeightLoad()
        {
            double load = - Material.Density * g / 1000 * Section.Area / 10000;
            ContinousLoads.Add(ContinousShearLoad.Create(0, load, this.Length, load));
        }

        private double SetNormalForceLoadVector(bool isLeftNode)
            => ContinousLoads.Sum(cl => cl.CalculateSpanLoadVectorNormalForceMember(this, isLeftNode)) +
                PointLoads.Sum(pl => pl.CalculateSpanLoadVectorNormalForceMember(this, isLeftNode)) +
                LeftNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadVectorNormalForceMember(this, isLeftNode) ?? 0) +
                RightNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadVectorNormalForceMember(this, isLeftNode) ?? 0);

        private double SetShearForceLoadVector(bool isLeftNode)
            => ContinousLoads.Sum(cl => cl.CalculateSpanLoadVectorShearMember(this, isLeftNode)) +
                PointLoads.Sum(pl => pl.CalculateSpanLoadVectorShearMember(this, isLeftNode)) +
                LeftNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadVectorShearMember(this, isLeftNode) ?? 0) +
                RightNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadVectorShearMember(this, isLeftNode) ?? 0);

        private double SetBendingMomentForceLoadVector(bool isLeftNode)
            => ContinousLoads.Sum(cl => cl.CalculateSpanLoadVectorBendingMomentMember(this, isLeftNode)) +
                PointLoads.Sum(pl => pl.CalculateSpanLoadBendingMomentMember(this, isLeftNode)) +
                LeftNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadBendingMomentMember(this, isLeftNode) ?? 0) +
                RightNode.ConcentratedForces.Where(cf => cf.IncludeInSpanLoadCalculations)
                .Sum(cf => (cf as ISpanLoad)?.CalculateSpanLoadBendingMomentMember(this, isLeftNode) ?? 0);
        
        #endregion // Private_Methods
  
    }
}
