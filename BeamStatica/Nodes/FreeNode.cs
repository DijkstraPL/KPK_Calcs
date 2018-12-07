using BeamStatica.Results.Displacements;
using BeamStatica.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Nodes
{
    public sealed class FreeNode : Node
    {
        public override short DegreesOfFreedom => 2;

        public FreeNode(IResultValue deflection = null, IResultValue rotation = null)
        {
            Deflection = deflection ?? new Deflection();
            LeftRotation = rotation ?? new Rotation();
            RightRotation = LeftRotation;
        }
        
        public override void SetDisplacementNumeration(ref short currentCounter)
        {
            MovementNumber = currentCounter++;
            LeftRotationNumber = currentCounter++;
            RightRotationNumber = LeftRotationNumber;
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {
        }
    }
}
