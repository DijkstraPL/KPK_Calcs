using Build_IT_Reports.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Reports.Interfaces
{
    public interface IReportPrinter
    {
        #region Public_Methods
        
        void Create(Report report);

        #endregion // Public_Methods
    }
}
