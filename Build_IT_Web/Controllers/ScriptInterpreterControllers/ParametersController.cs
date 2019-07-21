using Build_IT_Application.ScriptInterpreter.Parameters.Commands.CreateParameter;
using Build_IT_Application.ScriptInterpreter.Parameters.Commands.DeleteParameter;
using Build_IT_Application.ScriptInterpreter.Parameters.Commands.UpdateParameter;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries.GetAllParametersForScript;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Build_IT_Web.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/scripts")]
    [ApiController]
    public class ParametersController : BaseController
    {
        [HttpGet("{scriptId}/parameters/{lang?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ParameterResource>>> GetAllParameters(long scriptId, string lang = TranslationService.DefaultLanguageCode)
        {
            return Ok(await Mediator.Send(new GetAllParametersForScriptQuery { ScriptId = scriptId, Language = lang }));
        }

        [HttpPost("{scriptId}/parameters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateParameter(long scriptId, [FromBody] CreateParameterCommand command)
        {
            command.ScriptId = scriptId;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{scriptId}/parameters/{parId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateParameter(long scriptId, long parId, [FromBody] UpdateParameterCommand command)
        {
            command.ScriptId = scriptId;
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{scriptId}/parameters/{parId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteParameter(long parId)
        {
            await Mediator.Send(new DeleteParameterCommand { Id = parId });

            return NoContent();
        }
    }
}
