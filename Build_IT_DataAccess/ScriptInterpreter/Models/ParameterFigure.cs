using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.Models
{
    public class ParameterFigure
    {
        public long ParameterId { get; set; }
        public long FigureId { get; set; }
        public Parameter Parameter { get; set; }
        public Figure Figure { get; set; }
    }
}
