using Build_IT_BeamStatica.Beams.Interfaces;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Linq;

namespace Build_IT_BeamStatica.Beams
{
    internal class GlobalStiffnessMatrix : IGlobalStiffnessMatrix
    {
        #region Properties

        public Matrix<double> Matrix { get; private set; }
        public Matrix<double> InversedMatrix => Matrix.Inverse();

        #endregion //  Properties

        #region Fields

        private readonly IBeam _beam;

        #endregion //  Fields

        #region Constructors

        public GlobalStiffnessMatrix(IBeam beam)
        {
            _beam = beam ?? throw new ArgumentNullException(nameof(beam));
        }

        #endregion //  Constructors

        #region Public_Methods

        public void Calculate()
        {
            if (_beam.NumberOfDegreesOfFreedom != 0)
                Matrix = Matrix<double>.Build.Dense(_beam.NumberOfDegreesOfFreedom, _beam.NumberOfDegreesOfFreedom);

            for (int row = 0; row < _beam.NumberOfDegreesOfFreedom; row++)
                for (int col = 0; col < _beam.NumberOfDegreesOfFreedom; col++)
                    SetMatrixValues(row, col);
        }

        #endregion //  Public_Methods

        #region Private_Methods

        private void SetMatrixValues(int row, int col)
        {
            Matrix[row, col] += _beam.Spans.SelectMany(s => s.StiffnessMatrix.MatrixOfPositions)
                .Where(m => m.RowNumber == row && m.ColumnNumber == col).Sum(m => m.Value);
        }
        
        #endregion //  Private_Methods
    }
}
