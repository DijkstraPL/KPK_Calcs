using Build_IT_Data.Entities.Scripts;
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
        public int Type { get; set; }
        public int Flags { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
        public virtual List<Token> Tokens { get; set; }

        #endregion // Properties
    }
}
