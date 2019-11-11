using Build_IT_Data.Entities.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Entities.Scripts.Translations
{
    public class VersionTranslation
    {
        #region Properties

        public long Id { get; set; }
        public Version Version { get; set; }
        public long VersionId { get; set; }

        public Language Language { get; set; }
        public string Description { get; set; }

        #endregion // Properties
    }
}
