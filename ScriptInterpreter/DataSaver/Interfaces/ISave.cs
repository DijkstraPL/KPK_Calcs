using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.DataSaver.Interfaces
{
    public interface ISave
    {
        void SaveData(object IClass, string filename);
    }
}
