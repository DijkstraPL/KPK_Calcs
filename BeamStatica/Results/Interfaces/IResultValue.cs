using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Results.Interfaces
{
    public interface IResultValue
    {
        double Value { get; set; }
        double? Position { get; }
    }
}
