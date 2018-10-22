using BeamStatica.Loads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Loads.ContinousLoads
{
    public class ContinousLoad
    {
        public IPosition StartPosition { get; set; }
        public IPosition EndPosition { get; set; }

        public ILoadValue StartLoad { get; set; }
        public ILoadValue EndLoad { get; set; }

        public ContinousLoad(IPosition startPosition, IPosition endPosition, ILoadValue startLoad, ILoadValue endLoad)
        {
            StartPosition = startPosition ?? throw new ArgumentNullException(nameof(startPosition));
            EndPosition = endPosition ?? throw new ArgumentNullException(nameof(endPosition));
            StartLoad = startLoad ?? throw new ArgumentNullException(nameof(startLoad));
            EndLoad = endLoad ?? throw new ArgumentNullException(nameof(endLoad));
        }
    }
}
