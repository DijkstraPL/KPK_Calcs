using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoads.WindLoadsCases
{
    public abstract class WindLoadCase
    {
        public double GetExternalCoefficientBetween(
            double externalPressureCoefficientOneMeter,
            double externalPressureCoefficientTenMeters,
            double area) 
            => externalPressureCoefficientOneMeter -
                (externalPressureCoefficientOneMeter - externalPressureCoefficientTenMeters)
                * Math.Log10(area);
    }
}
