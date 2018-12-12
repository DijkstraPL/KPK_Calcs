﻿using BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.Interfaces
{
    public interface IContinousLoad
    {
        ILoadWithPosition StartPosition { get; }
        ILoadWithPosition EndPosition { get; }
        double Length { get; }

        double CalculateNormalForce(double distanceFromLoadStartPosition);
        double CalculateShear(double distanceFromLoadStartPosition);
        double CalculateBendingMoment(double distanceFromLoadStartPosition);

        double CalculateSpanLoadVectorNormalForceMember(ISpan span, bool leftNode);
        double CalculateSpanLoadVectorShearMember(ISpan span, bool leftNode);
        double CalculateSpanLoadBendingMomentMember(ISpan span, bool leftNode);
    }
}
