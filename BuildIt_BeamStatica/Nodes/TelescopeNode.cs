﻿using Build_IT_BeamStatica.Results.Displacements;
using Build_IT_BeamStatica.Results.Interfaces;
using Build_IT_BeamStatica.Results.Reactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Nodes
{
    public class TelescopeNode : Node
    {
        public override short DegreesOfFreedom => 1;

        public TelescopeNode(IResultValue normalForce = null, IResultValue bendingMoment = null, IResultValue verticalDeflection = null)
        {
            NormalForce = normalForce ?? new NormalForce();
            BendingMoment = bendingMoment ?? new BendingMoment();
            VerticalDeflection = verticalDeflection ?? new VerticalDeflection();
        }

        public override void SetDisplacementNumeration(ref short currentCounter)
        {
            VerticalMovementNumber = currentCounter++;
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {
            HorizontalMovementNumber = currentCounter++;
            LeftRotationNumber = currentCounter++;
            RightRotationNumber = LeftRotationNumber;
        }
    }
}