using Build_IT_Data.Entities.Scripts.Enums;

namespace Build_IT_Data.Entities.Scripts.Translations
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
