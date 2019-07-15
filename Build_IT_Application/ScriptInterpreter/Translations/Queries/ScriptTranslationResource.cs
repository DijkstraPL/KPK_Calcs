using Build_IT_Data.Entities.Scripts.Enums;
using System.ComponentModel.DataAnnotations;

namespace Build_IT_Application.ScriptInterpreter.Translations.Queries
{
    public class ScriptTranslationResource
    {
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ScriptId { get; set; }
        public string Notes { get; set; }
       // public ScriptResource Script { get; set; }
        public Language Language { get; set; }

        #endregion // Properties

        #region Constructors

        public ScriptTranslationResource()
        {
        }

        #endregion // Constructors
    }
}
