using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_DataAccess.ScriptInterpreter.Models
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}