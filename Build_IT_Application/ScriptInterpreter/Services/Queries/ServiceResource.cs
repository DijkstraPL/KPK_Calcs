using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.ScriptInterpreter.Services.Queries
{
    public class ServiceResource
    {
        #region Properties
        
        public string ContractName { get; set; }
        public string Description { get; set; }
        public IEnumerable<SimplePropertyResource> Properties { get; set; }
        public IEnumerable<SimplePropertyResource> Results { get; set; }

        #endregion // Properties
    }
}
