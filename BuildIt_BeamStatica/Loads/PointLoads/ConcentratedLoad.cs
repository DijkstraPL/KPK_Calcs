using Build_IT_BeamStatica.Loads.Interfaces;

namespace Build_IT_BeamStatica.Loads.PointLoads
{
    internal abstract class ConcentratedLoad : INodeLoad
    {
        public double Value { get; }
        public virtual bool IncludeInSpanLoadCalculations => false;

        protected ConcentratedLoad(double value)
        {
            Value = value;
        }

        public virtual double CalculateNormalForce() => 0;
        public virtual double CalculateShear() => 0;
        public virtual double CalculateBendingMoment(double distanceFromLoad) => 0;

        public virtual double CalculateHorizontalDisplacement() => 0;
        public virtual double CalculateVerticalDisplacement() => 0;
        public virtual double CalculateRotationDisplacement() => 0;

        public virtual double CalculateJointLoadVectorNormalForceMember() => 0;
        public virtual double CalculateJointLoadVectorShearMember() => 0;
        public virtual double CalculateJointLoadVectorBendingMomentMember() => 0;
    }
}
