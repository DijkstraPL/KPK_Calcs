using BeamStatica.Spans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Beams.Interfaces
{
    public interface IBeam : IResultProvider
    {
        double Length { get; }
        IList<ISpan> Spans { get; }

        void Calculate();
    }
}
