using Build_IT_BeamStatica.Spans.Interfaces;
using System.Collections.Generic;

namespace Build_IT_BeamStatica.Beams.Interfaces
{
    public interface IBeam : IResultProvider
    {
        #region Properties

        double Length { get; }
        IList<ISpan> Spans { get; }
        short NumberOfDegreesOfFreedom { get; }
        bool IncludeSelfWeight { get; }

        #endregion // Properties

        #region Public_Methods

        void Calculate();

        #endregion // Public_Methods
    }
}
