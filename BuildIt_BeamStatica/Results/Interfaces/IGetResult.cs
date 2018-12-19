using System.Collections.Generic;

namespace Build_IT_BeamStatica.Results.Interfaces
{
    public interface IGetResult
    {
        ICollection<IResultValue> Values { get; }

        void SetValues();
        IResultValue GetValue(double distanceFromLeftSide);
        IResultValue GetMaxValue(double startPosition = 0, double? endPosition = null);
        IResultValue GetMinValue(double startPosition = 0, double? endPosition = null);
    }
}
