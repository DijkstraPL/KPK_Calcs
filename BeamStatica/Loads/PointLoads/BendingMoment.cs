﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.PointLoads
{
    public sealed class BendingMoment : ConcentratedLoad
    {
        public BendingMoment(double value) : base(value)
        {
        }

        public override double CalculateNormalForce() => 0;

        public override double CalculateShear() => 0;

        public override double CalculateBendingMoment(double distanceFromLoad) 
            => this.Value;

        public override double CalculateSpanLoadVectorNormalForceMember(double spanLength, bool leftNode)
        {
            return 0;
        }

        public override double CalculateSpanLoadVectorShearMember(double spanLength, bool leftNode)
        {
            return 0;
        }

        public override double CalculateSpanLoadBendingMomentMember(double spanLength, bool leftNode)
        {
            return 0;
        }
    }
}
