using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.DataSaver.Interfaces
{
    public interface ILoad<T>
    {
        T LoadData(string filename);
    }
}
