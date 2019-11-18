using Build_IT_Data.Entities.Scripts.Enums;

namespace Build_IT_Application.ScriptInterpreter.Translations.Queries
{
    public class GroupTranslationResource
    {
        #region Properties

        public long Id { get; set; }
        public long GroupId { get; set; }

        public Language Language { get; set; }
        public string Name { get; set; }

        #endregion // Properties
    }
}
