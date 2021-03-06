﻿using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Data.Entities.Scripts.Translations;
using System.Collections.Generic;

namespace Build_IT_Data.Entities.Scripts
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
        public ICollection<ValueOption> ValueOptions { get; private set; }
        public ValueOptionSettings ValueOptionSetting { get; set; }
        public ParameterOptions Context { get; set; }
        public string GroupName { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public Script Script { get; set; }
        public long ScriptId { get; set; }
        public ICollection<ParameterFigure> ParameterFigures { get; private set; }

        public ICollection<ParameterTranslation> ParametersTranslations { get; private set; }

        #endregion // Properties

        #region Constructors

        public Parameter()
        {
            ValueOptions = new HashSet<ValueOption>();
            ParameterFigures = new HashSet<ParameterFigure>();
            ParametersTranslations = new HashSet<ParameterTranslation>();
        }

        #endregion // Constructors
    }
}
