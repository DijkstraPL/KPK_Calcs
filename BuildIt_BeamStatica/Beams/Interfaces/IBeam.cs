using Build_IT_BeamStatica.Spans.Interfaces;
using System.Collections.Generic;

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
