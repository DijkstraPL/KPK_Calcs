using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface IStiffnessMatrix
    {
        ICollection<IStiffnessMatrixPosition> MatrixOfPositions { get; }
        Matrix<double> Matrix { get; }
        int Size { get; }

        void Calculate();
    }
}
