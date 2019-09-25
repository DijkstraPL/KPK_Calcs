using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_FrameStatica.Results.Interfaces
{
    public interface IGetResult
    {
        #region Properties

        ICollection<IResultValue> Values { get; }

        #endregion // Properties

        #region Public_Methods

        void SetValues();
        IResultValue GetValue(double distanceFromLeftSide);
        IResultValue GetMaxValue(double startPosition = 0, double? endPosition = null);
        IResultValue GetMinValue(double startPosition = 0, double? endPosition = null);

        #endregion // Public_Methods
    }
}
