using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.PointLoads
{
    public sealed class ShearLoad : ConcentratedLoad
    {
        public ShearLoad(double value) : base(value)
        {
        }

        public ShearLoad(double value, double position) : base(value, position)
        {
        }

        public override double CalculateNormalForce() => 0;

        public override double CalculateShear() 
            => this.Value;

        public override double CalculateBendingMoment(double distanceFromLoad) 
            => this.Value * distanceFromLoad;

        public override double CalculateSpanLoadVectorNormalForceMember(double spanLength, bool leftNode)
            => 0;

        public override double CalculateSpanLoadVectorShearMember(double spanLength, bool leftNode)
        {
            double distanceFromCloserNode = leftNode ? this.Position : spanLength - this.Position;
            double distanceFromOtherNode = leftNode ? spanLength - this.Position : this.Position;
            return (-this.Value * Math.Pow(distanceFromOtherNode, 2) *
                (3 * distanceFromCloserNode + distanceFromOtherNode)) /
                Math.Pow(spanLength, 3);
        }

        public override double CalculateSpanLoadBendingMomentMember(double spanLength, bool leftNode)
        {
            double sign = leftNode ? 1.0 : -1.0;
            double distanceFromCloserNode = leftNode ? this.Position : spanLength - this.Position;
            double distanceFromOtherNode = leftNode ? spanLength - this.Position : this.Position;
            return sign * (-this.Value * distanceFromCloserNode * Math.Pow(distanceFromOtherNode, 2)) / Math.Pow(spanLength, 2);
        }
    }
}
