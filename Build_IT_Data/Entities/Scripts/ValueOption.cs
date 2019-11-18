using Build_IT_Data.Entities.Scripts.Translations;
using System.Collections.Generic;

namespace Build_IT_Data.Entities.Scripts
{
    public class ValueOption
    {
        #region Properties
        
        public long Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public Parameter Parameter { get; set; }
        public long ParameterId { get; set; }
        public ICollection<ValueOptionTranslation> ValueOptionsTranslations { get; private set; }

        #endregion // Properties

        #region Constructors

        public ValueOption()
        {
            ValueOptionsTranslations = new HashSet<ValueOptionTranslation>();
        }

        #endregion // Constructors
    }
}
