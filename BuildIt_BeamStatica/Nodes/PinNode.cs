using Build_IT_BeamStatica.Results.Displacements;
using Build_IT_BeamStatica.Results.Interfaces;
using Build_IT_BeamStatica.Results.Reactions;

namespace Build_IT_BeamStatica.Nodes
{
    internal class PinNode : Node
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
