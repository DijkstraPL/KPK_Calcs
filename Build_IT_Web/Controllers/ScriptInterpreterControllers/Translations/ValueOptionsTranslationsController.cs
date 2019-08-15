using AutoMapper;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.CreateValueOptionTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.DeleteValueOptionTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.UpdateValueOptionTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Queries.GetValueOptionsTranslations;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Data.Entities.Scripts.Translations;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources.Translations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers.Translations
{
    [Route("api/valueOptionsTranslations")]
    [ApiController]
    public class ValueOptionsTranslationsController : BaseController
    {
        [HttpGet("{parameterId}/{lang}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetValueOptionsTranslations(long parameterId, Language lang)
        {
            return Ok(await Mediator.Send(new GetValueOptionsTranslationsQuery { ParameterId = parameterId, Language = lang }));
        }
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Authorize()]
        public async Task<IActionResult> CreateValueOptionTranslation([FromBody] CreateValueOptionTranslationCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{valueOptionTranslationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize()]
        public async Task<IActionResult> UpdateValueOptionTranslation(long valueOptionTranslationId, [FromBody] UpdateValueOptionTranslationCommand command)
        {
            command.Id = valueOptionTranslationId;
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{valueOptionTranslationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize()]
        public async Task<IActionResult> DeleteValueOptionTranslation(long valueOptionTranslationId)
        {
            await Mediator.Send(new DeleteValueOptionTranslationCommand { Id = valueOptionTranslationId });

            return NoContent();
        }
    }
}