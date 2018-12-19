using MathNet.Numerics.LinearAlgebra;

namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface ISpanCalculations
    {
        void CalculateSpanLoadVector();
        void CalculateDisplacement(Vector<double> deflectionVector, int numberOfDegreesOfFreedom);
        void SetDisplacement();
        void CalculateForce();
    }
}
