using Build_IT_Application.Infrastructures;
using Build_IT_Application.ScriptInterpreter.Scripts.Commands.CreateScript;
using Build_IT_Application.ScriptInterpreter.Scripts.Commands.DeleteScript;
using Build_IT_Application.ScriptInterpreter.Scripts.Commands.UpdateScript;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries.GetAllScripts;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries.GetScript;
using Build_IT_Data.Entities.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/scripts")]
    [ApiController]
    public class ScriptsController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ScriptsController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("{lang?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ScriptResource>>> GetScripts(string lang = TranslationService.DefaultLanguageCode)
        {
            var currentUserId = GetCurrentUserId();
            var isAdmin = await IsCurrentUserAdmin();

            return Ok(await Mediator.Send(new GetAllScriptsQuery
            {
                Language = lang,
                CurrentUserId = currentUserId,
                IsAdmin = isAdmin
            }));
        }

        [HttpGet("{id}/{lang?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ScriptResource>> GetScript(long id, string lang = TranslationService.DefaultLanguageCode)
        {
            var currentUserId = GetCurrentUserId();
            var isAdmin = await IsCurrentUserAdmin();

            return Ok(await Mediator.Send(new GetScriptQuery
            {
                Id = id,
                Language = lang,
                CurrentUserId = currentUserId,
                IsAdmin = isAdmin
            }));
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize()]
        public async Task<IActionResult> Create([FromBody]CreateScriptCommand command)
        {
            command.Author = GetCurrentUserId();

            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize()]
        public async Task<IActionResult> UpdateScript([FromBody]UpdateScriptCommand command)
        {
            command.Author = GetCurrentUserId();
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize()]
        public async Task<IActionResult> Delete(long id)
        {
            var currentUserId = GetCurrentUserId();

            await Mediator.Send(new DeleteScriptCommand { Id = id, CurrentUserId = currentUserId });

            return NoContent();
        }

        #region Private_Methods

        private string GetCurrentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        private async Task<bool> IsCurrentUserAdmin()
        {
            var role = await _roleManager.FindByNameAsync("Administrator");
            var user = _userManager.Users.FirstOrDefault(u => u.Id == GetCurrentUserId());
            if (user != null && role != null)
                return await _userManager.IsInRoleAsync(user, role.Name);
            return false;
        }

        #endregion // Private_Methods
    }
}