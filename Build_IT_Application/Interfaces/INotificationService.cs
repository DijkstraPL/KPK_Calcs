using Build_IT_Application.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_Application.Interfaces
{
    public interface INotificationService
    {
        #region Public_Methods
        
        Task SendAsync(Message message);

        #endregion // Public_Methods
    }
}
