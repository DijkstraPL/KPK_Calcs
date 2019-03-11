using Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Spans.Interfaces;
using System;

namespace Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Spans
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
            if (rowNumber < 0 || columnNumber < 0)
                throw new ArgumentOutOfRangeException();

            Value = value;
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
        }

        #endregion // Constructors
    }
}
