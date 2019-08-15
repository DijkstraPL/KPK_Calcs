using System;
using System.Collections.Generic;

namespace Build_IT_Reports.Models
{
    public class Report
    {
        #region Properties
        
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Document { get; set; }

        public IEnumerable<Section> Sections { get; set; }

        #endregion // Properties
    }
}
