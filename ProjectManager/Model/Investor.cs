using System;
using System.Collections.Generic;

namespace ProjectManager.Model
{
    class Investor
    {
        /// <summary>
        /// Investor's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Investor's city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Investor's street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Investor's post code.
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// Investor's project list.
        /// </summary>
        public List<Project> ProjectList { get; set; }
    }
}
