using Build_IT_Data.Entities.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Entities.Scripts.Translations
{
    public  class GroupTranslation
    {
        #region Properties
               
        public long Id { get; set; }
        public Group Group { get; set; }
        public long GroupId { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }

        #endregion // Properties               
    }
}
