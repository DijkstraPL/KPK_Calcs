using Build_IT_DataAccess.ScriptInterpreter.Models.Translations;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Build_IT_DataAccess.ScriptInterpreter.Models
{
    public class ValueOption
    {
        #region Properties
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public Parameter Parameter { get; set; }
        public long ParameterId { get; set; }
        public ICollection<ValueOptionTranslation> ValueOptionsTranslations { get; set; }

        #endregion // Properties

        #region Constructors

        public ValueOption()
        {
            ValueOptionsTranslations = new Collection<ValueOptionTranslation>();
        }

        #endregion // Constructors
    }
}
