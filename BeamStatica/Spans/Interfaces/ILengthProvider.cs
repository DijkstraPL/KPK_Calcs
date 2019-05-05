using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace BeamStatica.Spans.Interfaces
{
    public interface ILengthProvider
    {
        [Abbreviation("L")]
        [Unit("m")]
        double Length { get; }
    }
}
