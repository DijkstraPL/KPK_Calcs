using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.ContinousLoads.Interfaces
{
    public interface IForceResult
    {
        double GetValue(double distanceFromLoadStartPosition);
    }
}
