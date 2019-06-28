using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.Models.Translations
{
    public class ValueOptionTranslation
    {
        #region Properties
        
        public long Id { get; set; }
        public ValueOption ValueOption { get; set; }
        public long ValueOptionId { get; set; }

        public Language Language { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        #endregion // Properties
    }
}
