using Build_IT_Application.Infrastructures;
using Build_IT_Application.ScriptInterpreter.Groups.Commands.CreateGroup;
using Build_IT_Application.ScriptInterpreter.Groups.Commands.DeleteGroup;
using Build_IT_Application.ScriptInterpreter.Groups.Commands.UpdateGroup;
using Build_IT_Application.ScriptInterpreter.Groups.Queries;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries.GetAllParametersForScript;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/scripts")]
    [ApiController]
    public class GroupsController : BaseController
    {
        #region Ppublic_Methods
        
        [HttpGet("{scriptId}/groups/{lang?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GroupResource>>> GetAllGroups(long scriptId, string lang = TranslationService.DefaultLanguageCode)
        {
            return Ok(await Mediator.Send(new GetAllGroupsForScriptQuery { ScriptId = scriptId, Language = lang }));
        }

        [HttpPost("{scriptId}/groups")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize()]
        public async Task<IActionResult> CreateGroup(long scriptId, [FromBody] CreateGroupCommand command)
        {
            command.ScriptId = scriptId;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{scriptId}/groups/{groupId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize()]
        public async Task<IActionResult> UpdateGroup(long scriptId, long groupId, [FromBody] UpdateGroupCommand command)
        {
            command.ScriptId = scriptId;
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{scriptId}/groups/{groupId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize()]
        public async Task<IActionResult> DeleteGroup(long groupId)
        {
            await Mediator.Send(new DeleteGroupCommand { Id = groupId });

            return NoContent();
        }

        #endregion // Ppublic_Methods
    }
}