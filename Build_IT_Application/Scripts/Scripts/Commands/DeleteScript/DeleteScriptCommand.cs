using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.Scripts.Scripts.Commands.DeleteScript
{
    public class DeleteScriptCommand : IRequest
    {
        #region Properties
        
        public long Id { get; set; }

        #endregion // Properties        
    }
}
