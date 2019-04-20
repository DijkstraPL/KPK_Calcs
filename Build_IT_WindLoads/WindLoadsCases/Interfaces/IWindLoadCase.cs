using Build_IT_WindLoads.BuildingData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoads.WindLoadsCases.Interfaces
{
    public interface IWindLoadCase
    {
        IDictionary<Field, double> GetExternalPressureCoefficientsMax();
        IDictionary<Field, double> GetExternalWindPressureMaxAt(double height);
    }
}
