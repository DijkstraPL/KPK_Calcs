using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Models.Translations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Build_IT_DataAccess.ScriptInterpreter.Models
{
    public class Script
    {
        #region Properties
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ScriptTag> Tags { get; set; }
        public string GroupName { get; set; }
        public string Author { get; set; }
        public DateTime Added { get; set; }
        public DateTime Modified { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public string Version { get; set; }
        public Language DefaultLanguage { get; set; }
        public ICollection<Parameter> Parameters { get; set; }
        public ICollection<ScriptTranslation> ScriptTranslations { get; set; }

        #endregion // Properties

        #region Constructors
        
        public Script()
        {
            Tags = new Collection<ScriptTag>();
            Parameters = new Collection<Parameter>();
            ScriptTranslations = new Collection<ScriptTranslation>();
        }

        #endregion // Constructors
    }
}
