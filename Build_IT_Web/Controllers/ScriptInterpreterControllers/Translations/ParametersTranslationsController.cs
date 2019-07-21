using AutoMapper;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.CreateParameterTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.DeleteParameterTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.UpdateParameterTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Queries.GetParametersTranslation;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Data.Entities.Scripts.Translations;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources.Translations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers.Translations
{
    [Route("api/parametersTranslations")]
    [ApiController]
    public class ParametersTranslationsController : BaseController
    {
        [HttpGet("{scriptId}/{lang}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetParametersTranslation(long scriptId, Language lang)
        {
            return Ok(await Mediator.Send(new GetParametersTranslationQuery { ScriptId = scriptId, Language = lang }));
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateParameterTranslation([FromBody] CreateParameterTranslationCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{parameterTranslationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateParameterTranslation(long parameterTranslationId, [FromBody] UpdateParameterTranslationCommand command)
        {
            command.Id = parameterTranslationId;
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{parameterTranslationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteParameterTranslation(long parameterTranslationId)
        {
            await Mediator.Send(new DeleteParameterTranslationCommand { Id = parameterTranslationId });

            return NoContent();
        }
    }
}