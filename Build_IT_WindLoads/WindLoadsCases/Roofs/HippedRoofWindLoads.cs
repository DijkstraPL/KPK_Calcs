using System;
using System.Collections.Generic;
using System.Text;
using Build_IT_WindLoads.BuildingData;
using Build_IT_WindLoads.BuildingData.Interfaces;

namespace Build_IT_WindLoads.WindLoadsCases.Roofs
{
    public class HippedRoofWindLoads : WindLoadCase
    {
        public HippedRoofWindLoads(IStructure building, IWindLoadData windLoadData) : base(building, windLoadData)
        {
        }

        public override IEnumerable<IDictionary<Field, double>> CalculatePressureCoefficients()
        {
            throw new NotImplementedException();
        }

        public override IDictionary<Field, double> GetExternalPressureCoefficientsMax()
        {
            throw new NotImplementedException();
        }

        public override IDictionary<Field, double> GetExternalPressureCoefficientsMin()
        {
            throw new NotImplementedException();
        }
    }
}
