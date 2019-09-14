using Build_IT_BeamStatica.Results.Interfaces;
using System.Collections.Generic;

namespace Build_IT_BeamStatica
{
    public class BeamCalculationResult
    {
        #region Properties
        
        private Dictionary<double, double> _normalForces = new Dictionary<double, double>();
        public IReadOnlyDictionary<double, double> NormalForces => _normalForces;

        private Dictionary<double, double> _shearForces = new Dictionary<double, double>();
        public IReadOnlyDictionary<double, double> ShearForces => _shearForces;

        private Dictionary<double, double> _bendingMoments = new Dictionary<double, double>();
        public IReadOnlyDictionary<double, double> BendingMoments => _bendingMoments;

        private Dictionary<double, double> _horizontalDeflections = new Dictionary<double, double>();
        public IReadOnlyDictionary<double, double> HorizontalDeflections => _horizontalDeflections;

        private Dictionary<double, double> _verticalDeflections = new Dictionary<double, double>();
        public IReadOnlyDictionary<double, double> VerticalDeflections => _verticalDeflections;

        private Dictionary<double, double> _rotations = new Dictionary<double, double>();
        public IReadOnlyDictionary<double, double> Rotations => _rotations;

        #endregion // Properties

        #region Constructors
        
        public BeamCalculationResult(IResultsContainer resultsContainer)
        {
            SetResults(_normalForces, resultsContainer.NormalForce.Values);
            SetResults(_shearForces, resultsContainer.Shear.Values);
            SetResults(_bendingMoments, resultsContainer.BendingMoment.Values);
            SetResults(_horizontalDeflections, resultsContainer.HorizontalDeflection.Values);
            SetResults(_verticalDeflections, resultsContainer.VerticalDeflection.Values);
            SetResults(_rotations, resultsContainer.Rotation.Values);
        }

        #endregion // Constructors

        #region Private_Methods
        
        private void SetResults(IDictionary<double, double> resultContainer, ICollection<IResultValue> results)
        {
            foreach (var result in results)
                resultContainer.Add(result.Position ?? 0, result.Value);
        }

        #endregion // Private_Methods
    }
}
