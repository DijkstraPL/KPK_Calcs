using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Calculators.Interfaces
{
    public interface IResult
    {
        #region Properties

        object this[string name] { get; set; }
        IDictionary<string, string> Descriptions { get; }

        #endregion // Properties

        #region Public_Methods

        IDictionary<string, object> GetProperties();

        #endregion // Public_Methods
    }
}
