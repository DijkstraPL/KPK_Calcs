using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.Models
{
    public class ParameterPhoto
    {
        public long ParameterId { get; set; }
        public long PhotoId { get; set; }
        public Parameter Parameter { get; set; }
        public Photo Photo { get; set; }
    }
}
