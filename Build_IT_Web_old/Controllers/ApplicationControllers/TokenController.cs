using Build_IT_Application.Application.User.Commands.GetToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ApplicationControllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        #region Fields

        private IRequestHandler<TokenRequestCommand, TokenResponseQuery> _tokenRequestCommandHandler;

        #endregion // Fields

        #region Constructors

        public TokenController(IRequestHandler<TokenRequestCommand, TokenResponseQuery> handler)
        {
            _tokenRequestCommandHandler = handler;
        }

        #endregion // Constructors

        #region Public_Methods

        [HttpPost("auth")]
        public async Task<IActionResult> Authorize([FromBody]TokenRequestCommand command)
        {
            return Ok(await _tokenRequestCommandHandler.Handle(command, CancellationToken.None));
        }

        #endregion // Public_Methods
    }
}
