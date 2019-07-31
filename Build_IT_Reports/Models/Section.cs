using System.Collections.Generic;

namespace Build_IT_Reports.Models
{
    public class Section
    {
        #region Properties
        
        public string Header { get; set; }
        public IEnumerable<Data> Data { get; set; }

        #endregion // Properties
    }
}
