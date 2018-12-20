using Build_IT_ScriptInterpreter.DataSaver.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Build_IT_ScriptInterpreter.DataSaver
{
    public class XmlLoad<T> : ILoad<T>
    {
        public static Type type;
        public XmlLoad()
        {
            type = typeof(T);
        }
        public T LoadData(string filename)
        {
            T result;
            XmlSerializer xmlserializer = new XmlSerializer(type);
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            result = (T)xmlserializer.Deserialize(fs);
            fs.Close();
            fs.Dispose();
            return result;
        }
    }
}
