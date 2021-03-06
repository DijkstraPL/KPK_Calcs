﻿using BeamStatica.Spans.Interfaces;

namespace BeamStatica.Spans
{
    public class StiffnessMatrixPosition : IStiffnessMatrixPosition
    {
        public short RowNumber { get; }
        public short ColumnNumber { get; }
        public double Value { get; set;  }

        public StiffnessMatrixPosition(double value, short rowNumber, short columnNumber)
        {
            Value = value;
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
        }
    }
}
