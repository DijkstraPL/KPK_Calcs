using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_DataAccess.ScriptInterpreter.Models
{
    public class AlternativeScript
    {
        public long Id { get; set; }
        public string ScriptName { get; set; }
        public Parameter Parameter { get; set; }
        public long ParameterId { get; set; }
    }
}