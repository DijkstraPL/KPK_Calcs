using BeamStatica.Loads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Nodes.Interfaces
{
    public interface INode : INormalForceProvider, IShearForceProvider, IBendingMomentProvider, 
        IDeflectionProvider, IRotationProvider, INumeration
    {
        double Angle { get; }
        short DegreesOfFreedom { get; }
        ICollection<INodeLoad> ConcentratedForces { get; set; }
    }
}
