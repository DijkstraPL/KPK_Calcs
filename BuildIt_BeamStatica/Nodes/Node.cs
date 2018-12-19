using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Nodes.Interfaces;
using Build_IT_BeamStatica.Results.Interfaces;
using System.Collections.Generic;

namespace Build_IT_BeamStatica.Nodes
{
    public abstract class Node : INode
    {
        public double Angle { get; protected set; } 

        public short HorizontalMovementNumber { get; protected set; }
        public short VerticalMovementNumber { get; protected set; }
        public short LeftRotationNumber { get; protected set; }
        public short RightRotationNumber { get; protected set; }

        public abstract short DegreesOfFreedom { get; }

        public ICollection<INodeLoad> ConcentratedForces { get; set; } = new List<INodeLoad>();

        public IResultValue NormalForce { get; protected set; } = null;
        public IResultValue ShearForce { get; protected set; } = null;
        public IResultValue BendingMoment { get; protected set; } = null;

        public IResultValue HorizontalDeflection { get; protected set; } = null;
        public IResultValue VerticalDeflection { get; protected set; } = null;
        public IResultValue LeftRotation { get; protected set; } = null;
        public IResultValue RightRotation { get; protected set; } = null;

        public abstract void SetDisplacementNumeration(ref short currentCounter);
        public abstract void SetReactionNumeration(ref short currentCounter);

    }
}
