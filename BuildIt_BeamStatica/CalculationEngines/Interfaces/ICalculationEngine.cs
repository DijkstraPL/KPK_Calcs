using Build_IT_BeamStatica.Beams.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_BeamStatica.CalculationEngines.Interfaces
{
    public interface ICalculationEngine
    {
        void Calculate(IBeam beam);
    }
}
