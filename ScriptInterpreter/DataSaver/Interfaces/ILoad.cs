using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.DataSaver.Interfaces
{
    public interface ILoad<T>
    {
        #region Public_Methods

        T LoadData(string filename);

        #endregion // Public_Methods
    }
}
