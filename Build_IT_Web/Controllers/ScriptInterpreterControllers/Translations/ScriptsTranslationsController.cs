using Build_IT_Application.ScriptInterpreter.Translations.Commands.CreateScriptTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.DeleteScriptTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.UpdateScriptTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Queries.GetScriptTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Queries.GetScriptTranslations;
using Build_IT_Data.Entities.Scripts.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers.Translations
{
    [Route("api/scriptsTranslations")]
    [ApiController]
    public class ScriptsTranslationsController : BaseController
    {
        [HttpGet("{scriptId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetScriptTranslations(long scriptId)
        {
            return Ok(await Mediator.Send(new GetScriptTranslationsQuery { ScriptId = scriptId }));
        }

        [HttpGet("{scriptId}/{lang}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetScriptTranslation(long scriptId, Language lang)
        {
            return Ok(await Mediator.Send(new GetScriptTranslationQuery { ScriptId = scriptId, Language = lang }));
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateScriptTranslation([FromBody] CreateScriptTranslationCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{scriptId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateScriptTranslation(long scriptId, [FromBody] UpdateScriptTranslationCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{scriptId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteParameterTranslation(long scriptId)
        {
            await Mediator.Send(new DeleteScriptTranslationCommand { Id = scriptId });

            return NoContent();
        }
    }
}