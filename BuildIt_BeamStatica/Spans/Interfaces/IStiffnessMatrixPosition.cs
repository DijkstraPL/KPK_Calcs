using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface IStiffnessMatrixPosition
    {
        short RowNumber { get; }
        short ColumnNumber { get; }
        double Value { get; set; }
    }
}
