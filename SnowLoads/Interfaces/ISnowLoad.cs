using Tools;

namespace SnowLoads.Interfaces
{
    public interface ISnowLoad : ISnowDensityProvider, IReturnPeriodProvider, IExceptionalSituationProvider
    {    
        /// <summary>
        /// Current design situation enumerator - <see cref="DesignSituation"/>.
        /// </summary>
        DesignSituation CurrentDesignSituation { get; set; }

        /// <summary>
        /// Characteristic value of snow on the ground at the relevant site.
        /// </summary>
        [Abbreviation("s_k")]
        [Unit("kN/m2")]
        double DefaultCharacteristicSnowLoad { get; }

        /// <summary>
        /// Instance of class implementing <see cref="IBuildingSite"/>.
        /// </summary>
        IBuildingSite BuildingSite { get; }

        /// <summary>
        /// Calculate characteristic snow load on ground.
        /// </summary>
        void CalculateSnowLoad();
    }
}
