using Build_IT_BeamStatica.Beams.Interfaces;
using MathNet.Numerics.LinearAlgebra;

namespace Build_IT_BeamStatica.CalculationEngines.Interfaces
{
    public interface IBeamCalculationEngine
    {
        #region Public_Methods

        void Calculate();

        #endregion // Public_Methods
    }
}
