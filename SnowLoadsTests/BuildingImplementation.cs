using SnowLoads.Interfaces;

namespace SnowLoads.Tests
{
    public class BuildingImplementation : Interfaces.IBuilding
    {
        public double ThermalCoefficient { get; set; }

        public double InternalTemperature { get; set; }

        public double TempreatureDifference { get; set; }

        public double OverallHeatTransferCoefficient { get; set; }

        public ISnowLoad SnowLoad { get; set; }

        public void CalculateThermalCoefficient()
        {
            ThermalCoefficient = 0.9;
        }
    }
}