
using Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Spans.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;
using MathNet.Numerics.LinearAlgebra;

namespace Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Spans.Interfaces
{
    public interface ISpanCalculationEngine
    {
        #region Properties

        IStiffnessMatrix StiffnessMatrix { get; }
                
        Vector<double> LoadVector { get; }
        Vector<double> Displacements { get; }
        Vector<double> Forces { get; }

        #endregion // Properties

        #region Public_Methods
        
        void CalculateSpanLoadVector();
        void CalculateDisplacement(Vector<double> deflectionVector, int numberOfDegreesOfFreedom);
        void CalculateForce();

        #endregion // Public_Methods
    }
}
