using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Data.Entities.Scripts.Translations;
using System;
using System.Collections.Generic;

namespace Build_IT_Data.Entities.Scripts
{
    public class Script
    {
        #region Properties
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ScriptTag> Tags { get; private set; }
        public string GroupName { get; set; }
        public string Author { get; set; }
        public DateTime Added { get; set; }
        public DateTime Modified { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public ICollection<Version> Versions { get; private set; }
        public bool IsPublic { get; set; }
        public Language DefaultLanguage { get; set; }
        public ICollection<Parameter> Parameters { get; private set; }
        public ICollection<ScriptTranslation> ScriptTranslations { get; private set; }

        #endregion // Properties

        #region Constructors

        public Script()
        {
            Tags = new HashSet<ScriptTag>();
            Versions = new HashSet<Version>();
            Parameters = new HashSet<Parameter>();
            ScriptTranslations = new HashSet<ScriptTranslation>();
        }

        #endregion // Constructors
    }
}
