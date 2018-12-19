using Build_IT_BeamStatica.Results.Displacements;
using Build_IT_BeamStatica.Results.Interfaces;

namespace Build_IT_BeamStatica.Nodes
{
    public class FreeNode : Node
    {
        public override short DegreesOfFreedom => 3;

        public FreeNode(IResultValue horizontalDeflection = null, IResultValue verticalDeflection = null,
            IResultValue rotation = null)
        {
            HorizontalDeflection = horizontalDeflection ?? new HorizontalDeflection();
            VerticalDeflection = verticalDeflection ?? new VerticalDeflection();
            LeftRotation = rotation ?? new Rotation();
            RightRotation = LeftRotation;
        }
        
        public override void SetDisplacementNumeration(ref short currentCounter)
        {
            HorizontalMovementNumber = currentCounter++;
            VerticalMovementNumber = currentCounter++;
            LeftRotationNumber = currentCounter++;
            RightRotationNumber = LeftRotationNumber;
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {
        }
    }
}
