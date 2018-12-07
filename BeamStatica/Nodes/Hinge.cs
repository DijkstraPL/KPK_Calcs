using BeamStatica.Results.Displacements;
using BeamStatica.Results.Interfaces;

namespace BeamStatica.Nodes
{
    public class Hinge : Node
    {
        public override short DegreesOfFreedom => 3;

        public Hinge(IResultValue deflection = null, IResultValue leftRotation = null, IResultValue rightRotation = null)
        {
            Deflection = deflection ?? new Deflection();
            LeftRotation = leftRotation ?? new Rotation();
            RightRotation = rightRotation ?? new Rotation();
        }

        public override void SetDisplacementNumeration(ref short currentCounter)
        {
            MovementNumber = currentCounter++;
            LeftRotationNumber = currentCounter++;
            RightRotationNumber = currentCounter++;
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {            
        }
    }
}
