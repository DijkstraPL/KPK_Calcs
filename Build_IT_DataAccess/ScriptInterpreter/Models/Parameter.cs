using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_DataAccess.ScriptInterpreter.Models
{
    public class Parameter
    {
        #region Properties
        
        public long Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public ValueTypes ValueType { get; set; }
        public string Value { get; set; }
        public string VisibilityValidator { get; set; }
        public string DataValidator { get; set; }
        public string Unit { get; set; }
        public ICollection<ValueOption> ValueOptions { get; set; }
        public ValueOptionSettings ValueOptionSetting { get; set; }
        public ParameterOptions Context { get; set; }
        public string GroupName { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public Script Script { get; set; }
        public long ScriptId { get; set; }
        public ICollection<ParameterFigure> ParameterFigures { get; set; }

        #endregion // Properties

        #region Constructors
        
        public Parameter()
        {
            ValueOptions = new Collection<ValueOption>();
            ParameterFigures = new Collection<ParameterFigure>();
        }

        #endregion // Constructors
    }
}
