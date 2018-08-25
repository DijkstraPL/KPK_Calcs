using Tools;

namespace SnowLoads.Interfaces
{
    public interface IExceptionalSituationProvider
    {       
        /// <summary>
        /// Is situation for calculations exceptional.
        /// </summary>
        bool ExcepctionalSituation { get; set; }

        /// <summary>
        /// Coefficient for exceptional snow loads.
        /// </summary>
        [Abbreviation("C_esl")]
        [Unit("")]
        double ExceptionalSnowLoadCoefficient { get; }
    }
}