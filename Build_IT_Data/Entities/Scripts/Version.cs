using Build_IT_Data.Entities.Scripts.Translations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Entities.Scripts
{
    public class Version
    {
        #region Properties
        
        public long Id { get; set; }
        public string Description { get; set; }
        public string AccordingTo { get; set; }
        public Script Script { get; set; }
        public long ScriptId { get; set; }
        public DateTime Added { get; set; }
        public DateTime Modified { get; set; }
        public string Author { get; set; }
        public bool IsPublic { get; set; }
        public ICollection<Parameter> Parameters { get; private set; }
        public ICollection<VersionTranslation> ScriptTranslations { get; private set; }

        #endregion // Properties

        #region Constructors

        public Version()
        {
            Parameters = new HashSet<Parameter>();
        }

        #endregion // Constructors
    }
}
