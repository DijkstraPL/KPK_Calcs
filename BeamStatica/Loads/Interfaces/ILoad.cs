using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.Interfaces
{
    public interface ILoad : ILoadPosition
    {
        double CalculateNormalForce();
        double CalculateShear();
        double CalculateBendingMoment(double distanceFromLoad);

        double CalculateSpanLoadVectorNormalForceMember(double spanLength, bool leftNode);
        double CalculateSpanLoadVectorShearMember(double spanLength, bool leftNode);
        double CalculateSpanLoadBendingMomentMember(double spanLength, bool leftNode);
    }
}
