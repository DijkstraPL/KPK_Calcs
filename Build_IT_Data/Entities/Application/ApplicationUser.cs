using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Data.Entities.Application
{
    public class ApplicationUser : IdentityUser
    {
        #region Properties
        
        public string DisplayName { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        #endregion // Properties
    }
}
