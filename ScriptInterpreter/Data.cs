using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptInterpreter
{
    public class Data
    {
        public string Name { get; set; }
        public string Translation { get; set; }
        public string Description { get; set; }

        public IEnumerable<double> AvailableVaues { get; set; }


    }
}
