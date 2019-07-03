using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources.Translations
{
    public class ParameterTranslationResource
    {
        #region Properties

        public long Id { get; set; }
        public ParameterResource Parameter { get; set; }
        public long ParameterId { get; set; }

        public Language Language { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string GroupName { get; set; }

        #endregion // Properties
    }
}
