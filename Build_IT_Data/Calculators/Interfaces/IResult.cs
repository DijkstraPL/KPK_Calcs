using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Calculators.Interfaces
{
    public interface IResult
    {
        #region Properties
        
        IDictionary<string, object> Properties { get; }

        #endregion // Properties
    }
}
