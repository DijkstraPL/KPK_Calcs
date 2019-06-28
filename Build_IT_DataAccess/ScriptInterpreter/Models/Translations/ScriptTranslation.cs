using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.Models.Translations
{
    public class ScriptTranslation
    {
        #region Properties
        
        public long Id { get; set; }
        public Script Script { get; set; }
        public long ScriptId { get; set; }

        public Language Language { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }

        #endregion // Properties
    }
}
