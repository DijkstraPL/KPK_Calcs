using System;

namespace BeamStatica.Loads.PointLoads
{
    public sealed class BendingMoment : ConcentratedLoad
    {
        public BendingMoment(double value) : base(value)
        {
        }

        public BendingMoment(double value, double position) : base(value, position)
        {
        }

        public override double CalculateNormalForce() => 0;

        public override double CalculateShear() => 0;

        public override double CalculateBendingMoment(double distanceFromLoad)
            => this.Value;

        public override double CalculateSpanLoadVectorNormalForceMember(double spanLength, bool leftNode)
            => 0;

        public override double CalculateSpanLoadVectorShearMember(double spanLength, bool leftNode)
        {
            double sign = leftNode ? -1.0 : 1.0;
            double distanceFromCloserNode = leftNode ? this.Position : spanLength - this.Position;
            double distanceFromOtherNode = leftNode ? spanLength - this.Position : this.Position;
            return (sign * 6 * this.Value * distanceFromCloserNode * distanceFromOtherNode) / Math.Pow(spanLength, 3);
        }

        public override double CalculateSpanLoadBendingMomentMember(double spanLength, bool leftNode)
        {
            double distanceFromCloserNode = leftNode ? this.Position : spanLength - this.Position;
            double distanceFromOtherNode = leftNode ? spanLength - this.Position : this.Position;
            return (-this.Value * distanceFromOtherNode
                * (2 * distanceFromCloserNode - distanceFromOtherNode))
                / Math.Pow(spanLength, 2);
        }
    }
}
