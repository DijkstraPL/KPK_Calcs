using Build_IT_BeamStatica.Results.Displacements;
using Build_IT_BeamStatica.Results.Interfaces;
using Build_IT_BeamStatica.Results.Reactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Nodes
{
    public class SleeveNode : Node
    {
        public override short DegreesOfFreedom => 1;

        public SleeveNode(IResultValue shearForce = null, IResultValue bendingMoment = null, IResultValue horizontalDeflection = null)
        {
            ShearForce = shearForce ?? new ShearForce();
            BendingMoment = bendingMoment ?? new BendingMoment();
            HorizontalDeflection = horizontalDeflection ?? new HorizontalDeflection ();
        }

        public override void SetDisplacementNumeration(ref short currentCounter)
        {
            HorizontalMovementNumber = currentCounter++;
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {
            VerticalMovementNumber = currentCounter++;
            LeftRotationNumber = currentCounter++;
            RightRotationNumber = LeftRotationNumber;
        }
    }
}
