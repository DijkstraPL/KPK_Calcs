using Build_IT_ScriptInterpreter.DataSaver.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Build_IT_ScriptInterpreter.DataSaver
{
    public class XmlSave : ISave
    {
        #region Public_Methods

        public void SaveData(object IClass, string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer((IClass.GetType()));
                writer = new StreamWriter(filename);
                xmlSerializer.Serialize(writer, IClass);

            }
            finally
            {
                if (writer != null)
                    writer.Close();
                writer = null;
            }
        }

        #endregion // Public_Methods
    }
}
