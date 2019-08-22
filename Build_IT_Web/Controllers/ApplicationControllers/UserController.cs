using Build_IT_Application.Application.User.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ApplicationControllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Fields
        
        private IRequestHandler<CreateUserCommand> _createUserCommandHandler;

        #endregion // Fields

        #region Constructors

        public UserController(IRequestHandler<CreateUserCommand> handler)
        {
            _createUserCommandHandler = handler;
        }

        #endregion // Constructors

        #region Public_Methods
        
        [HttpPut()]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommand command)
        {
            return Ok(await _createUserCommandHandler.Handle(command, CancellationToken.None));
        }

        #endregion // Public_Methods
    }
}
