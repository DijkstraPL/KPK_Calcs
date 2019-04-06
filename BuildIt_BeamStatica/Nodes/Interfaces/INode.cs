using Build_IT_BeamStatica.Loads.Interfaces;
using System.Collections.Generic;

namespace Build_IT_BeamStatica.Nodes.Interfaces
{
    public interface INode : INormalForceProvider, IShearForceProvider, IBendingMomentProvider, 
        IDeflectionProvider, IRotationProvider, INumeration
    {
        double Angle { get; }
        double RadiansAngle { get; }

        short DegreesOfFreedom { get; }
        ICollection<INodeLoad> ConcentratedForces { get; set; }
    }
}
