using BeamStatica.Results.Displacements;
using BeamStatica.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Nodes
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
