using Build_IT_Application.Application.User.Commands.GetToken;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ApplicationControllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : BaseController
    {
        [HttpPost("auth")]
        public async Task<IActionResult> Authorize([FromBody]TokenRequestCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
