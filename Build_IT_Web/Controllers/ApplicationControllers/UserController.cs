using Build_IT_Application.Application.User.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ApplicationControllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPut()]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
