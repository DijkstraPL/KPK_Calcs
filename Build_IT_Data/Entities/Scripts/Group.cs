using System.Collections.Generic;

namespace Build_IT_Data.Entities.Scripts
{
    public class Group
    {
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public string VisibilityValidator { get; set; }
        public ICollection<Parameter> Parameters { get; private set; }
        public long ScriptId { get; set; }
        public Script Script { get; set; }

        #endregion // Properties

        #region Constructors

        public Group()
        {
            Parameters = new HashSet<Parameter>();
        }

        #endregion // Constructors
    }
}
