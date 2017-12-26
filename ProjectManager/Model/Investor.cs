using System;
using System.Collections.Generic;

namespace ProjectManager.Model
{
    /// <summary>
    /// Investor data template.
    /// </summary>
    public class Investor
    {
        /// <value>Investor's name.</value>
        public string Name { get; set; }

        /// <value>Investor's city.</value>
        public string City { get; set; }

        /// <value>Investor's street.</value>
        public string Street { get; set; }

        /// <value>Investor's post code.</value>
        public string PostCode { get; set; }

        /// <value>Investor's project list.</value>
        public List<Project> ProjectList { get; set; }
    }
}
