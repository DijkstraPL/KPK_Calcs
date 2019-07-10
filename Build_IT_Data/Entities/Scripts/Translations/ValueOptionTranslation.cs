using Build_IT_Data.Entities.Scripts.Enums;

namespace Build_IT_Data.Entities.Scripts.Translations
{
    public class ValueOptionTranslation
    {
        #region Properties
        
        public long Id { get; set; }
        public ValueOption ValueOption { get; set; }
        public long ValueOptionId { get; set; }

        public Language Language { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #endregion // Properties
    }
}
