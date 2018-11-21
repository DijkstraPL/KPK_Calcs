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
    public sealed class SupportedNode : Node
    {
        public override short DegreesOfFreedom => 1;

        public SupportedNode(IResultValue shearForce = null, IResultValue rotation = null)
        {
            ShearForce = shearForce ?? new ShearForce();
            Rotation = rotation ?? new Rotation();
        }

        public override void SetDisplacementNumeration(ref short currentCounter)
        {
            RotationNumber = currentCounter++;
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {
            MovementNumber = currentCounter++;
        }
    }
}
