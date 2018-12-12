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
    public sealed class PinNode : Node
    {
        public override short DegreesOfFreedom => 2;

        public PinNode(IResultValue shearForce = null, IResultValue horizontalDeflection = null, IResultValue rotation = null)
        {
            HorizontalDeflection = horizontalDeflection ?? new HorizontalDeflection();
            ShearForce = shearForce ?? new ShearForce();
            LeftRotation = rotation ?? new Rotation();
            RightRotation = LeftRotation;
        }

        public override void SetDisplacementNumeration(ref short currentCounter)
        {
            HorizontalMovementNumber = currentCounter++;
            LeftRotationNumber = currentCounter++;
            RightRotationNumber = LeftRotationNumber;
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {
            VerticalMovementNumber = currentCounter++;
        }
    }
}
