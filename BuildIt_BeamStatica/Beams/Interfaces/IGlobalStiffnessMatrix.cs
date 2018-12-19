using MathNet.Numerics.LinearAlgebra;

namespace Build_IT_BeamStatica.Beams.Interfaces
{
    public interface IGlobalStiffnessMatrix
    {
        Matrix<double> Matrix { get; }
        Matrix<double> InversedMatrix { get; }

        void Calculate();
    }
}
