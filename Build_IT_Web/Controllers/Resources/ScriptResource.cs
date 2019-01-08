using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.Resources
{
    public class ScriptResource
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TagResource> Tags { get; set; } = new Collection<TagResource>();
        public string GroupName { get; set; }
        public string Author { get; set; }
        public DateTime Added { get; set; }
        public DateTime Modified { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public ICollection<ParameterResource> Parameters { get; set; } = new Collection<ParameterResource>();
    }
}
