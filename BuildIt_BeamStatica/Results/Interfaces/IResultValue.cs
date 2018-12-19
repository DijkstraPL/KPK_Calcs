using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Results.Interfaces
{
    public interface IResultValue
    {
        double Value { get; set; }
        double? Position { get; }
    }
}
