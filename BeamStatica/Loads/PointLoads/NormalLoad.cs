using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.PointLoads
{
    public class NormalLoad : ConcentratedLoad
    {
        public NormalLoad(double value) : base(value)
        {
        }

        public NormalLoad(double value, double position) : base(value, position)
        {
        }

        public override double CalculateNormalForce() 
            => this.Value;

        public override double CalculateShear() => 0;

        public override double CalculateBendingMoment(double distanceFromLoad) => 0;

        public override double CalculateSpanLoadVectorNormalForceMember(double spanLength, bool leftNode)
        {
            double distanceFromCloserNode = leftNode ? this.Position : spanLength - this.Position;
            double distanceFromOtherNode = leftNode ? spanLength - this.Position : this.Position;
            return -this.Value * distanceFromOtherNode / spanLength;
        }

        public override double CalculateSpanLoadVectorShearMember(double spanLength, bool leftNode) => 0;

        public override double CalculateSpanLoadBendingMomentMember(double spanLength, bool leftNode) => 0;
    }
}
