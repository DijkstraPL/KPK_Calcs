using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.Models.Translations
{
    public class ParameterTranslation
    {
        #region Properties
        
        public long Id { get; set; }
        public Parameter Parameter { get; set; }
        public long ParameterId { get; set; }

        public Language Language { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string GroupName { get; set; }

        #endregion // Properties
    }
}
