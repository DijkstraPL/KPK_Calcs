using MathNet.Numerics.LinearAlgebra;

namespace Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Beams.Interfaces
{
    public interface IGlobalStiffnessMatrix
    {
        #region Properties

        Matrix<double> Matrix { get; }
        Matrix<double> InversedMatrix { get; }

        #endregion // Properties

        #region Public_Methods

        void Calculate();

        #endregion // Public_Methods
    }
}
