using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.Interfaces
{
    public interface INodeLoad : ILoad
    {
        bool IncludeInSpanLoadCalculations { get; }

        double CalculateNormalForce();
        double CalculateShear();
        double CalculateBendingMoment(double distanceFromLoad);
        double CalculateVerticalDisplacement();

        double CalculateJointLoadVectorNormalForceMember();
        double CalculateJointLoadVectorShearMember();
        double CalculateJointLoadVectorBendingMomentMember();
    }
}
