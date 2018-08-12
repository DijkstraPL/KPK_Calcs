using ReinforcementAnchoring.Interfaces;
using Tools;

namespace ReinforcementAnchoring.Coefficients
{
    public class WeldedTransverseBarCoefficient : ICoefficient
    {
        #region Properties

        [Abbreviation("alpha_4")]
        public double Coefficient { get; private set; } = 1;

        #endregion // Properties

        #region Methods

        public void Calculate()
        {
            Coefficient = 0.7;
        }

        #endregion // Methods
    }
}
