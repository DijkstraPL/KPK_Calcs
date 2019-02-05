using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStatica.Spans
{
    internal class StiffnessMatrixPosition : IStiffnessMatrixPosition
    {
        #region Properties

        public short RowNumber { get; }
        public short ColumnNumber { get; }
        public double Value { get; set;  }

        #endregion // Properties

        #region Constructors
        
        public StiffnessMatrixPosition(double value, short rowNumber, short columnNumber)
        {
            Value = value;
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
        }

        #endregion // Constructors
    }
}
