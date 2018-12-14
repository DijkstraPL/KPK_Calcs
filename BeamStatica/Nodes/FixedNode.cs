using BeamStatica.Results.Interfaces;
using BeamStatica.Results.Reactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Nodes
{
    public class FixedNode : Node
    {
        public override short DegreesOfFreedom => 0;

        public FixedNode(IResultValue normalForce = null, IResultValue shearForce = null, IResultValue bendingMoment = null)
        {
            NormalForce = normalForce ?? new NormalForce();
            ShearForce = shearForce ?? new ShearForce();
            BendingMoment = bendingMoment ?? new BendingMoment();
        }

        public override void SetDisplacementNumeration(ref short currentCounter)
        {           
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {
            HorizontalMovementNumber = currentCounter++;
            VerticalMovementNumber = currentCounter++;
            LeftRotationNumber = currentCounter++;
            RightRotationNumber = LeftRotationNumber;
        }
    }
}
