using BeamStatica.Loads.Interfaces;
using BeamStatica.Nodes.Interfaces;
using BeamStatica.Results.Displacements;
using BeamStatica.Results.Interfaces;
using BeamStatica.Results.Reactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Nodes
{
    public abstract class Node : INode
    {
        public short MovementNumber { get; protected set; }
        public short RotationNumber { get; protected set; }

        public virtual short DegreesOfFreedom { get; }

        public ICollection<ILoadValue> ConcentratedForces { get; set; } = new List<ILoadValue>();

        public IResultValue BendingMoment { get; protected set; } = null;
        public IResultValue ShearForce { get; protected set; } = null;
        public IResultValue Rotation { get; protected set; } = null;
        public IResultValue Deflection { get; protected set; } = null;

        public abstract void SetDisplacementNumeration(ref short currentCounter);
        public abstract void SetReactionNumeration(ref short currentCounter);

    }
}
