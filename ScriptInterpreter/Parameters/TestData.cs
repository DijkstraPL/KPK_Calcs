using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreter.Parameters
{
    public class TestData
    {
        public string TestCase { get; }

        public ICollection<IParameter> Parameters { get; }
        public ICollection<IParameter> ExpectedResults { get; }


    }
}
