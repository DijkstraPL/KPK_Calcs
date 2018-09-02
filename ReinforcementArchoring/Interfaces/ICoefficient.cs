using Tools;

namespace ReinforcementAnchoring.Interfaces
{
    public interface ICoefficient
    {
        /// <summary>
        /// Coefficient which change the design anchorage length.
        /// </summary>
        /// <remarks>[PN-EN 1992-1-1 Table 8.2]</remarks>
        [Abbreviation("alpha_i")]
        [Unit("")]
        double Coefficient { get; }
        void Calculate();
    }
}
