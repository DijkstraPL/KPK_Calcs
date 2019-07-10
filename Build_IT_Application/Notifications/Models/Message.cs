using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.Notifications.Models
{
    public class Message
    {
        #region Properties
        
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        #endregion // Properties
    }
}
