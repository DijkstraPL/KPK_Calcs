using Build_IT_BeamStatica.Beams.Interfaces;
using MathNet.Numerics.LinearAlgebra;

namespace Build_IT_BeamStatica.CalculationEngines.Interfaces
{
    public interface IBeamCalculationEngine
    {
        #region Properties

        IBeam Beam { get; }

        Vector<double> JointLoadVector { get; }
        Vector<double> SpanLoadVector { get; }
        Vector<double> DeflectionVector { get; }

        #endregion // Properties

        #region Public_Methods

        void Calculate();

        #endregion // Public_Methods
    }
}
