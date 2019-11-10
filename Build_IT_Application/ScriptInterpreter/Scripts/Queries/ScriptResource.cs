using Build_IT_Application.ScriptInterpreter.Tags.Queries;
using Build_IT_Data.Entities.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Build_IT_Application.ScriptInterpreter.Scripts.Queries
{
    public class ScriptResource
    {
        #region Properties
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TagResource> Tags { get; set; }
        public string GroupName { get; set; }
        public DateTime Added { get; set; }
        public DateTime Modified { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public Language DefaultLanguage { get; set; }
        public bool IsPublic { get; set; }
        public bool IsEditable { get; set; }

        #endregion // Properties

        #region Constructors

        public ScriptResource()
        {
            Tags = new HashSet<TagResource>();
        }

        #endregion // Constructors
    }
}
