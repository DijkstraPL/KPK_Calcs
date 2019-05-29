using Build_IT_ScriptInterpreter.DataSaver.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Build_IT_ScriptInterpreter.DataSaver
{
    [Obsolete]
    public class XmlLoad<T> : ILoad<T>
    {
        #region Fields

        private Type _type;

        #endregion // Fields

        #region Constructors

        public XmlLoad()
        {
            _type = typeof(T);
        }

        #endregion // Constructors

        #region Public_Methods

        public T LoadData(string filename)
        {
            T result;
            XmlSerializer xmlserializer = new XmlSerializer(_type);
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            result = (T)xmlserializer.Deserialize(fs);
            fs.Close();
            return result;
        }

        #endregion // Public_Methods
    }
}
