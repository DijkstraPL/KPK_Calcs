using Build_IT_BeamStatica.Results.Displacements;
using Build_IT_BeamStatica.Results.Interfaces;
using Build_IT_BeamStatica.Results.Reactions;
using System;

namespace Build_IT_BeamStatica.Nodes
{
    internal class PinNode : Node
    {
        public override short DegreesOfFreedom => 2;
        
        public PinNode(
            IResultValue shearForce = null,
            IResultValue horizontalDeflection = null,
            IResultValue rotation = null,
            double angle = 0)
        {
            ShearForce = shearForce ?? new ShearForce();
            HorizontalDeflection = horizontalDeflection ?? new HorizontalDeflection();
            LeftRotation = rotation ?? new Rotation();
            RightRotation = LeftRotation;

            Angle = angle % 360;
            if (Angle != 0 && Angle != 180 )
            {
                NormalForce = new NormalForce();
                VerticalDeflection = new VerticalDeflection();
            }
            if(Angle == 90 || Angle == 270)
            {
                ShearForce = null;
                HorizontalDeflection = null;
            }
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
