using Build_IT_BeamStatica.Loads.ContinousLoads;
using Build_IT_BeamStatica.Loads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface ILoadProvider
    {
         ICollection<IContinousLoad> ContinousLoads { get; set; }
         ICollection<ISpanLoad> PointLoads { get; set; }
    }
}
