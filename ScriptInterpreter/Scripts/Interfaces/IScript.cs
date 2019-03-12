using Build_IT_ScriptInterpreter.DataSaver.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Scripts.Interfaces
{
    public interface IScript : ICalculatable
    {
        #region Properties

        string Name { get; }
       string Description { get; }
       List<string> Tags { get; }
       string GroupName { get; }
       string Author { get; }
       DateTime Added { get; }
       DateTime Modified { get; }
       string AccordingTo { get;}
       string Notes { get;  }

        #endregion // Properties
    }
}
