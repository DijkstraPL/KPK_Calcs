using Build_IT_Data.Calculators.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Calculators
{
    public class Result : IResult
    {
        #region Properties
        
        public IDictionary<string, object> Properties { get; private set; }

        #endregion // Properties

        #region Constructors
        
        public Result()
        {
            Properties = new Dictionary<string, object>();
        }

        #endregion // Constructors
    }
}
