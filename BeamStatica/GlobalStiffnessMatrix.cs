using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
            Matrix = Matrix<double>.Build.Dense(_beam.NumberOfDegreesOfFreedom, _beam.NumberOfDegreesOfFreedom);

            for (int i = 0; i < _beam.NumberOfDegreesOfFreedom; i++)
                for (int j = 0; j < _beam.NumberOfDegreesOfFreedom; j++)
                    SetMatrixValues(i, j);
        }

        private void SetMatrixValues(int i, int j)
        {
            Matrix[i, j] += _beam.Spans.SelectMany(s => s.StiffnessMatrix.MatrixOfPositions)
                .Where(m => m.RowNumber == i && m.ColumnNumber == j).Sum(m => m.Value);
        }
    }
}
