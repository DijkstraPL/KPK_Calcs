//using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnowLoads.Interfaces;

namespace SnowLoads.Tests
{
    public class BuildingSiteImplementation : IBuildingSite
    {
        public double AltitudeAboveSea { get; set; }
        public ZoneEnum CurrentZone { get; set; }
        public TopographyEnum CurrentTopography { get; set; }

        public double ExposureCoefficient { get; private set; }


        public BuildingSiteImplementation(double exposureCoefficient)
        {
            ExposureCoefficient = exposureCoefficient;
        }

        public void CalculateExposureCoefficient()
        {
            ExposureCoefficient = 1;
        }
    }
}