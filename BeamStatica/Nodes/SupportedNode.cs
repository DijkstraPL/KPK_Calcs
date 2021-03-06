﻿using BeamStatica.Results.Displacements;
using BeamStatica.Results.Interfaces;
using BeamStatica.Results.Reactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Nodes
{
    public class SupportedNode : Node
    {
        public override short DegreesOfFreedom => 1;

        public SupportedNode(IResultValue normalForce = null, IResultValue shearForce = null, IResultValue rotation = null)
        {
            NormalForce = normalForce ?? new NormalForce();
            ShearForce = shearForce ?? new ShearForce();
            LeftRotation = rotation ?? new Rotation();
            RightRotation = LeftRotation;
        }

        public override void SetDisplacementNumeration(ref short currentCounter)
        {
            LeftRotationNumber = currentCounter++;
            RightRotationNumber = LeftRotationNumber;
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {
            HorizontalMovementNumber = currentCounter++;
            VerticalMovementNumber = currentCounter++;
        }
    }
}
