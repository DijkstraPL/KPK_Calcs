using AutoMapper;
using Build_IT_Application.ScriptInterpreter.Tags.Commands.CreateTag;
using Build_IT_Application.ScriptInterpreter.Tags.Queries.GetAllTags;
using Build_IT_Application.ScriptInterpreter.Tags.Queries.GetAllTagsForScript;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagController : BaseController
    {
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ParameterResource>>> GetAllTags()
        {
            return Ok(await Mediator.Send(new GetAllTagsQuery()));
        }

        [HttpGet("{scriptId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ParameterResource>>> GetAllTagsForScript(long scriptId)
        {
            return Ok(await Mediator.Send(new GetAllTagsForScriptQuery { ScriptId = scriptId }));
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateTag(long scriptId, [FromBody] CreateTagCommand command)
        {
            var newTag = await Mediator.Send(command);

            return CreatedAtAction(nameof(CreateTag), newTag);
        }
    }
}