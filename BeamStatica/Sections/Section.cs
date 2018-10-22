using BeamStatica.Sections.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace BeamStatica.Sections
{
    public abstract class Section : IMomentOfInteria
    {
        [Abbreviation("I")]
        [Unit("cm4")]
        public double MomentOfInteria { get; set; }
    }
}
