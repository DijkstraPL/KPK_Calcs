using BeamStatica.Results.Displacements;
using BeamStatica.Results.Interfaces;
using BeamStatica.Results.Reactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Nodes
{
    public class TelescopeNode : Node
    {
        public override short DegreesOfFreedom => 1;

        public TelescopeNode( IResultValue bendingMoment = null, IResultValue deflection = null)
        {
            BendingMoment = bendingMoment ?? new BendingMoment();
            Deflection = deflection ?? new Deflection();
        }

        public override void SetDisplacementNumeration(ref short currentCounter)
        {
            MovementNumber = currentCounter++;
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {
            RotationNumber = currentCounter++;
        }
    }
}
