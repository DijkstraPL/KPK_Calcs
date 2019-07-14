using Build_IT_Application.Interfaces;
using Build_IT_Application.Notifications.Models;
using System.Threading.Tasks;

namespace Build_IT_Application.Infrastructures
{
    public class NotificationService : INotificationService
    {
        #region Public_Methods

        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }

        #endregion // Public_Methods
    }
}
