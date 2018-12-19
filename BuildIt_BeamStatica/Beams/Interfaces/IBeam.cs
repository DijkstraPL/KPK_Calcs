using Build_IT_BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Beams.Interfaces
{
    public interface IBeam : IResultProvider
    {
        double Length { get; }
        IList<ISpan> Spans { get; }
        short NumberOfDegreesOfFreedom { get; }

        void Calculate();
    }
}
