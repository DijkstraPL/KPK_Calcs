using Build_IT_Application.ScriptInterpreter.Figures.Queries;
using Build_IT_Application.ScriptInterpreter.Groups.Queries;
using Build_IT_Data.Entities.Scripts.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Build_IT_Application.ScriptInterpreter.Parameters.Queries
{
    public class ParameterResource
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
        public ICollection<ValueOptionResource> ValueOptions { get; set; }
        public ValueOptionSettings ValueOptionSetting { get; set; }
        public ParameterOptions Context { get; set; }
        public GroupResource Group { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public ICollection<FigureResource> Figures { get; set; }

        public string Equation { get; set; }

        #endregion // Properties

        #region Constructors

        public ParameterResource()
        {
            ValueOptions = new Collection<ValueOptionResource>();
            Figures = new Collection<FigureResource>();
        }

        #endregion // Constructors
    }
}