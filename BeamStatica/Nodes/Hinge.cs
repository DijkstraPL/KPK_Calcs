using BeamStatica.Results.Displacements;
using BeamStatica.Results.Interfaces;

namespace BeamStatica.Nodes
{
    public class Hinge : Node
    {
        public override short DegreesOfFreedom => 4;

        public Hinge(IResultValue horizontalDeflection = null, IResultValue verticalDeflection = null, 
            IResultValue leftRotation = null, IResultValue rightRotation = null)
        {
            HorizontalDeflection = horizontalDeflection ?? new VerticalDeflection();
            VerticalDeflection = verticalDeflection ?? new VerticalDeflection();
            LeftRotation = leftRotation ?? new Rotation();
            RightRotation = rightRotation ?? new Rotation();
        }

        public override void SetDisplacementNumeration(ref short currentCounter)
        {
            HorizontalMovementNumber = currentCounter++;
            VerticalMovementNumber = currentCounter++;
            LeftRotationNumber = currentCounter++;
            RightRotationNumber = currentCounter++;
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {            
        }
    }
}
