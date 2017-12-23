using System;

namespace ProjectManager.Model
{
    /// <summary>
    /// Information about projects
    /// </summary>
    public class Project
    {
        /// <value>Unique project Id.</value>
        public string Id { get; set; }
        
        /// <value>Project name.</value>
        public string Name { get; set; }
        
        /// <value>Name of city.</value>
        public string City { get; set; }
        
        /// <value>Street.</value>
        public string Street { get; set; }
        
        /// <value>Post Code.</value>
        public string PostCode { get; set; }
        
        /// <value>Registration number.</value>
        public string RegistrationNumber { get; set; }
        
        /// <value>Date.</value>
        public DateTime Date { get; set; }
        
    }
}
