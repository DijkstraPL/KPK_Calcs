using Build_IT_BeamStatica.Results.Displacements;
using Build_IT_BeamStatica.Results.Interfaces;
using Build_IT_BeamStatica.Results.Reactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Nodes
{
    public class PinNode : Node
    {
        public override short DegreesOfFreedom => 2;
        
        public PinNode(IResultValue shearForce = null,
            IResultValue horizontalDeflection = null, IResultValue rotation = null,
            double angle = 0)
        {
            ShearForce = shearForce ?? new ShearForce();
            HorizontalDeflection = horizontalDeflection ?? new HorizontalDeflection();
            LeftRotation = rotation ?? new Rotation();
            RightRotation = LeftRotation;

            Angle = angle;
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
