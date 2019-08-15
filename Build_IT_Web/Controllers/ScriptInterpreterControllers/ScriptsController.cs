using Build_IT_Application.ScriptInterpreter.Scripts.Commands.CreateScript;
using Build_IT_Application.ScriptInterpreter.Scripts.Commands.DeleteScript;
using Build_IT_Application.ScriptInterpreter.Scripts.Commands.UpdateScript;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries.GetAllScripts;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries.GetScript;
using Build_IT_Web.Services;
using Microsoft.AspNetCore.Authorization;
//using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/scripts")]
    [ApiController]
    public class ScriptsController : BaseController
    {
        [HttpGet("{lang?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ScriptResource>>> GetScripts(string lang = TranslationService.DefaultLanguageCode)
        {
            return Ok(await Mediator.Send(new GetAllScriptsQuery { Language = lang } ));
        }

        [HttpGet("{id}/{lang?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ScriptResource>> GetScript(long id, string lang = TranslationService.DefaultLanguageCode)
        {
            return Ok(await Mediator.Send(new GetScriptQuery { Id = id, Language = lang }));
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize()]
        public async Task<IActionResult> Create([FromBody]CreateScriptCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateScript([FromBody]UpdateScriptCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize()]
        public async Task<IActionResult> Delete(long id)
        {
            await Mediator.Send(new DeleteScriptCommand { Id = id });

            return NoContent();
        }
    }
}