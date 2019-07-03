using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources.Translations
{
    public class ScriptTranslationResource
    {
        #region Properties

        public long Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public long ScriptId { get; set; }
        public string Notes { get; set; }
        public ScriptResource Script { get; set; }
        public Language Language { get; set; }

        #endregion // Properties

        #region Constructors

        public ScriptTranslationResource()
        {
        }

        #endregion // Constructors
    }
}
