using Build_IT_Data.Entities.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.Scripts.Scripts.Commands.CreateScript
{
    public class CreateScriptCommand
    {
        #region Properties
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public string Author { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public Language DefaultLanguage { get; set; }

        #endregion // Properties
    }
}
