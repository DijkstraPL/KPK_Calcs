using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Results.Interfaces
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
