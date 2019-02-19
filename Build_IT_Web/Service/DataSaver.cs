using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_Web.Core.Models;
using System.Collections.Generic;

namespace Build_IT_Web.Service
{
    public class DataSaver
    {
        public void SaveScript(Script script, string path)
        {
            XmlSave xmlSave = new XmlSave();
            xmlSave.SaveData(script, path);
        }
    }
}
