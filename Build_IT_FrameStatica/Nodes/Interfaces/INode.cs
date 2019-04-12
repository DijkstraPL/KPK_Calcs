using Build_IT_FrameStatica.Coords;
using Build_IT_FrameStatica.Loads.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_FrameStatica.Nodes.Interfaces
{
    public interface INode : INormalForceProvider, IShearForceProvider, IBendingMomentProvider,
        IDeflectionProvider, IRotationProvider, INumeration
    {
        #region Properties

        Point Position { get; }
        
        short DegreesOfFreedom { get; }
        ICollection<INodeLoad> ConcentratedForces { get; set; }

        #endregion // Properties
    }
}
