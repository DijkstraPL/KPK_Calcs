﻿using Build_IT_BeamStatica.Loads.ContinousLoads.AlongTemperatureDifferenceResult;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Materials.Intefaces;
using Build_IT_BeamStatica.Sections.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Loads.ContinousLoads
{
    public class AlongTemperatureDifferenceLoad : ContinousLoad
    {
        public static IContinousLoad Create(ISpan span, double temperatureDifference)
        {
            return new AlongTemperatureDifferenceLoad(
                           new LoadData(0, 0),
                           new LoadData(span.Length, temperatureDifference));
        }

        private AlongTemperatureDifferenceLoad(
            ILoadWithPosition startPosition, ILoadWithPosition endPosition)
            : base(startPosition, endPosition)
        {
            HorizontalDeflectionResult = new HorizontalDeflectionResult(this);
        }
        
        public override double CalculateSpanLoadVectorNormalForceMember(ISpan span, bool leftNode)
        {
            double sign = leftNode ? 1.0 : -1.0;
             return sign * span.Material.ThermalExpansionCoefficient 
                * (EndPosition.Value - StartPosition.Value)
                * span.Section.Area * span.Material.YoungModulus * 100;
        }
    }
}