using Build_IT_CommonTools;
using Build_IT_WindLoads.BuildingData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoads.WindLoadsCases
{
    public class VerticalWallOfRectangularBuilding : WindLoadCase
    {
        public int ExternalPressureCoefficientOneSquareMeter { get; set; }
        public int ExternalPressureCoefficientTenSquareMeters { get; set; }

        private readonly IBuilding _building;
        private readonly IWindLoad _windLoad;

        public VerticalWallOfRectangularBuilding(IBuilding building, IWindLoad windLoad)
            : base()
        {
            _building = building;
            _windLoad = windLoad;
        }

        public IDictionary<string, double> GetExternalPressureCoefficientOneSquareMeter()
        {
            IDictionary<string, double> externalPresssureCoefficients;

            var windParallelBuildingWidth =
                _windLoad.BuildingRotated ?
                _building.Width :
                _building.Length;

            double heightToWindParallelWidthRatio = _building.Height / windParallelBuildingWidth;

            if (heightToWindParallelWidthRatio >= 5)
                externalPresssureCoefficients = SetValuesForRatioAbove5();
            else if (heightToWindParallelWidthRatio == 1)
                externalPresssureCoefficients = SetValuesForRatioEqual1();
            else if (heightToWindParallelWidthRatio <= 0.25)
                externalPresssureCoefficients = SetValuesForRatioLess0_25();
            else if (heightToWindParallelWidthRatio < 1)
                externalPresssureCoefficients = InterpolateBetweenFor(
                    SetValuesForRatioEqual1(),
                    SetValuesForRatioLess0_25(),
                    heightToWindParallelWidthRatio);
            else if (heightToWindParallelWidthRatio < 5)
                externalPresssureCoefficients = InterpolateBetweenFor(
                    SetValuesForRatioAbove5(),
                    SetValuesForRatioEqual1(),
                    heightToWindParallelWidthRatio);
        }

        private IDictionary<string, double> InterpolateBetweenFor(
            IDictionary<string, double> valuesForBiggerRatio ,
            IDictionary<string, double> valuesForSmallerRatio,
            double heightToWindParallelWidthRatio)
        {
            var externalPresssureCoefficients = new Dictionary<string, double>();
            foreach (var keyValuePair in valuesForSmallerRatio)
            {
                externalPresssureCoefficients.Add(
                    keyValuePair.Key,
                    Interpolation.InterpolateLinearBetween(
                        start: (0.25, keyValuePair.Value),
                        end: (1, valuesForBiggerRatio[keyValuePair.Key]),
                        at: heightToWindParallelWidthRatio)
                    );
            }
            return externalPresssureCoefficients;
        }

        private IDictionary<string, double> SetValuesForRatioAbove5()
            => new Dictionary<string, double>
            {
                {"A", -1.2 },
                {"B", -0.8 },
                {"C", -0.5 },
                {"D", 0.8 },
                {"E", -0.7 }
            };

        private IDictionary<string, double> SetValuesForRatioEqual1()
            => new Dictionary<string, double>
            {
                {"A", -1.2 },
                {"B", -0.8 },
                {"C", -0.5 },
                {"D", 0.8 },
                {"E", -0.5 }
            };

        private IDictionary<string, double> SetValuesForRatioLess0_25()
            => new Dictionary<string, double>
            {
                {"A", -1.2 },
                {"B", -0.8 },
                {"C", -0.5 },
                {"D", 0.7 },
                {"E", -0.3 }
            };
    }
}
