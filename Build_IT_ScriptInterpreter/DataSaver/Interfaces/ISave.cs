using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.DataSaver.Interfaces
{
    [Obsolete]
    public interface ISave
    {
        #region Public_Methods

        void SaveData(object IClass, string filename);

        #endregion // Public_Methods
    }
}
