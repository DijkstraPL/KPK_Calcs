using Build_IT_Data.Entities.Scripts.Enums;

namespace Build_IT_Application.ScriptInterpreter.Translations.Queries
{
    public class ParameterTranslationResource
    {
        #region Properties

        public long Id { get; set; }
        // public ParameterResource Parameter { get; set; }
        public long ParameterId { get; set; }

        public Language Language { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string GroupName { get; set; }

        #endregion // Properties
    }
}
