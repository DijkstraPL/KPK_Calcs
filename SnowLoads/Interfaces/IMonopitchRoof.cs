using Tools;

namespace SnowLoads.Interfaces
{
    public interface IMonopitchRoof : ICalculatable
    {     
        /// <summary>
        /// Slope for roof.
        /// </summary>
        [Abbreviation("alpha")]
        [Unit("degree")]
        double Slope { get; set; }

        /// <summary>
        /// Is there any obstacles, like snow fences.
        /// </summary>
        bool SnowFences { get; set; }

        /// <summary>
        /// Snow load shape coefficient 1.
        /// </summary>
        [Abbreviation("mi_1")]
        [Unit("")]
        double ShapeCoefficient { get; }

        /// <summary>
        /// Snow load on the roof.
        /// </summary>
        [Abbreviation("s")]
        [Unit("kN/m2")]
        double SnowLoadOnRoofValue { get; }
    }
}
