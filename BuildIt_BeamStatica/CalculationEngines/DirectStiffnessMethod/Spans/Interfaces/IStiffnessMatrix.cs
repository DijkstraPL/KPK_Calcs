using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

namespace Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Spans.Interfaces
{
    public interface IStiffnessMatrix
    {
        #region Properties

        ICollection<IStiffnessMatrixPosition> MatrixOfPositions { get; }
        Matrix<double> Matrix { get; }
        int Size { get; }

        #endregion // Properties

        #region Public_Methods

        void Calculate();

        #endregion // Public_Methods
    }
}
