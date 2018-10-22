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
        public override short DegreesOfFreedom { get; } = 2;

        public FreeNode(IResultValue deflection = null, IResultValue rotation = null)
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
