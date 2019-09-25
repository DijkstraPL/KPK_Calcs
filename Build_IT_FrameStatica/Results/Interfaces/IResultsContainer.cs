using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_FrameStatica.Results.Interfaces
{
    public interface IResultsContainer
    {
        #region Properties

        IGetResult NormalForce { get; }
        IGetResult Shear { get; }
        IGetResult BendingMoment { get; }
        IGetResult HorizontalDeflection { get; }
        IGetResult VerticalDeflection { get; }
        IGetResult Rotation { get; }

        #endregion // Properties
    }
}
