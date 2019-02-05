using MathNet.Numerics.LinearAlgebra;

namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface ISpanCalculations
    {
        #region Public_Methods

        void CalculateSpanLoadVector();
        void CalculateDisplacement(Vector<double> deflectionVector, int numberOfDegreesOfFreedom);
        void SetDisplacement();
        void CalculateForce();

        #endregion // Public_Methods
    }
}
