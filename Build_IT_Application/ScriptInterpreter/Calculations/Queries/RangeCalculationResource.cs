using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.ScriptInterpreter.Calculations.Queries
{
    public class RangeCalculationResource
    {
        #region Properties
        
        public IEnumerable<CalculateParameterResource> Parameters { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double Tick { get; set; }
        public long ParameterId { get; set; }

        #endregion // Properties
    }
}
