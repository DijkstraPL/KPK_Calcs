using Build_IT_Data.Entities.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources
{
    public class ScriptResource
    {
        #region Properties
        
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<TagResource> Tags { get; set; }
        [StringLength(255)]
        public string GroupName { get; set; }
        [StringLength(255)]
        public string Author { get; set; }
        public DateTime Added { get; set; }
        public DateTime Modified { get; set; }
        [StringLength(255)]
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public Language DefaultLanguage { get; set; }
        public ICollection<ParameterResource> Parameters { get; set; }

        #endregion // Properties

        #region Constructors
        
        public ScriptResource()
        {
            Tags = new Collection<TagResource>();
            Parameters = new Collection<ParameterResource>();
        }

        #endregion // Constructors
    }
}
