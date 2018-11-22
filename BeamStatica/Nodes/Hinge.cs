using BeamStatica.Results.Displacements;
using BeamStatica.Results.Interfaces;

namespace BeamStatica.Nodes
{
    public class Hinge : Node
    {
        public override short DegreesOfFreedom => 1;
       // public IResultValue LeftRotation { get; protected set; } = null;
       // public IResultValue RightRotation { get; protected set; } = null;
       

        public Hinge(IResultValue deflection = null, IResultValue rotation = null)
        {
            Deflection = deflection ?? new Deflection();
           // Rotation = rotation ?? new Rotation();
           // Rotation = rotation ?? new Rotation();
        }

        public override void SetDisplacementNumeration(ref short currentCounter)
        {
            MovementNumber = currentCounter++;
            // RotationNumber = currentCounter++;
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {            
        }
    }
}
