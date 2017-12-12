using System;

namespace ProjectManager.Model
{
    /// <summary>
    /// Information about projects
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Unique project Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Project name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Post Code.
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// Registration number.
        /// </summary>
        public string RegistrationNumber { get; set; }
        
        /// <summary>
        /// Date.
        /// </summary>
        public DateTime Date { get; set; }
        
    }
}
