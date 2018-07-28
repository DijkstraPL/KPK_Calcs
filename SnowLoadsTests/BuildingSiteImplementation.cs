//using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnowLoads.Interfaces;

namespace SnowLoads.Tests
{
    public class BuildingSiteImplementation : IBuildingSite
    {
        public double AltitudeAboveSea { get; set; }
        public Zone CurrentZone { get; set; }
        public Topography CurrentTopography { get; set; }

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