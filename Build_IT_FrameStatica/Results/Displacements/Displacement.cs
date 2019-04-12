using Build_IT_FrameStatica.Results.Interfaces;

namespace Build_IT_FrameStatica.Results.Displacements
{
    internal abstract class Displacement : IResultValue
    {
        #region Properties

        public double Value { get; set; }
        public double? Position { get; }

        #endregion // Properties

        #region Constructors
        
        protected Displacement(double? position = null)
        {
            Position = position;
        }

        #endregion // Constructors

        #region Public_Methods

        public override string ToString() => Value.ToString();

        #endregion // Public_Methods
    }
}
