using BeamStatica.Results.Displacements;
using BeamStatica.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Nodes
{
    public class Hinge : Node
    {
        public override short DegreesOfFreedom => 1;

        public Hinge(IResultValue deflection = null, IResultValue rotation = null)
        {
            Deflection = deflection ?? new Deflection();
            Rotation = rotation ?? new Rotation();
        }

        public override void SetDisplacementNumeration(ref short currentCounter)
        {
            MovementNumber = currentCounter++;
            RotationNumber = currentCounter++;
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {
        }
    }
}
