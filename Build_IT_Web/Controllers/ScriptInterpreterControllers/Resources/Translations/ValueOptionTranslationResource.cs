using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources.Translations
{
    public class ValueOptionTranslationResource
    {
        #region Properties

        public long Id { get; set; }
        public ValueOptionResource ValueOption { get; set; }
        public long ValueOptionId { get; set; }

        public Language Language { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #endregion // Properties

        #region Constructors

        public ValueOptionTranslationResource()
        {
        }

        #endregion // Constructors
    }
}
