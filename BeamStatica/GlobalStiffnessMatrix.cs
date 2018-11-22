using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System.Linq;

namespace BeamStatica
{
    public class GlobalStiffnessMatrix
    {
        public Matrix<double> Matrix { get; set; }
        public Matrix<double> InversedMatrix => Matrix.Inverse();

        private readonly Beam _beam;

        public GlobalStiffnessMatrix(Beam beam)
        {
            _beam = beam;
        }

        public void Calculate()
        {
            if (_beam.NumberOfDegreesOfFreedom != 0)
                Matrix = Matrix<double>.Build.Dense(_beam.NumberOfDegreesOfFreedom, _beam.NumberOfDegreesOfFreedom);

            for (int row = 0; row < _beam.NumberOfDegreesOfFreedom; row++)
                for (int col = 0; col < _beam.NumberOfDegreesOfFreedom; col++)
                    SetMatrixValues(row, col);
        }

        private void SetMatrixValues(int row, int col)
        {
            Matrix[row, col] += _beam.Spans.SelectMany(s => s.StiffnessMatrix.MatrixOfPositions)
                .Where(m => m.RowNumber == row && m.ColumnNumber == col).Sum(m => m.Value);
        }
    }
}
