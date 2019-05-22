using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_DataAccess.ScriptInterpreter.Models
{
    public class ValueOption
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public Parameter Parameter { get; set; }
        public long ParameterId { get; set; }
    }
}
