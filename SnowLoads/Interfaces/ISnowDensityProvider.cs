using Tools;

namespace SnowLoads.Interfaces
{
    public interface ISnowDensityProvider
    {       
        /// <summary>
        /// Density of the snow.
        /// </summary>
        [Abbreviation("gamma")]
        [Unit("kN/m3")]
        double SnowDensity { get; set; }
    }
}
