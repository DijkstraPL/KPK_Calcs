using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_ScriptInterpreter.DataSaver;

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
