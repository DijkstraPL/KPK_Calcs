using Build_IT_BeamStatica.Loads.Interfaces;
using System.Collections.Generic;

namespace Build_IT_BeamStatica.Spans.Interfaces
{
    public interface ILoadProvider
    {
         ICollection<IContinousLoad> ContinousLoads { get; set; }
         ICollection<ISpanLoad> PointLoads { get; set; }
    }
}
