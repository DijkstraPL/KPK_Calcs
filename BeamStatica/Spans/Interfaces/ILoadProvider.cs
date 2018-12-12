using BeamStatica.Loads.ContinousLoads;
using BeamStatica.Loads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Spans.Interfaces
{
    public interface ILoadProvider
    {
         ICollection<IContinousLoad> ContinousLoads { get; set; }
         ICollection<ISpanLoad> PointLoads { get; set; }
    }
}
