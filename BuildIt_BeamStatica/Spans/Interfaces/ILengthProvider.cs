using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Build_IT_Tools;

namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface ILengthProvider
    {
        [Abbreviation("L")]
        [Unit("m")]
        double Length { get; }
    }
}
