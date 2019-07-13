using Build_IT_Application.Interfaces;
using Build_IT_Application.Notifications.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.Scripts.Scripts.Commands.CreateScript
{
    public class ScriptCreated : INotification
    {
        #region Properties
        
        public long Id { get; set; }

        #endregion // Properties
        
        public class Handler : INotificationHandler<ScriptCreated>
        {
            #region Fields

            private readonly INotificationService _notification;

            #endregion // Fields

            #region Constructors

            public Handler(INotificationService notification)
            {
                _notification = notification;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task Handle(ScriptCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }

            #endregion // Public_Methods
        }
    }
}
