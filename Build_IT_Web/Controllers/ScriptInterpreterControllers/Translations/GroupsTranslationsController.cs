using AutoMapper;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.CreateGroupTranslationCommand;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.CreateParameterTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.DeleteGroupTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.DeleteParameterTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.UpdateGroupTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.UpdateParameterTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Queries.GetGroupsTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Queries.GetParametersTranslation;
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
    [Route("api/groupsTranslations")]
    [ApiController]
    public class GroupsTranslationsController : BaseController
    {
        [HttpGet("{scriptId}/{lang}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGroupsTranslation(long scriptId, Language lang)
        {
            return Ok(await Mediator.Send(new GetGroupsTranslationQuery { ScriptId = scriptId, Language = lang }));
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Authorize()]
        public async Task<IActionResult> CreateParameterTranslation([FromBody] CreateGroupTranslationCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{groupTranslationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize()]
        public async Task<IActionResult> UpdateParameterTranslation(long groupTranslationId, [FromBody] UpdateGroupTranslationCommand command)
        {
            command.Id = groupTranslationId;
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{groupTranslationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize()]
        public async Task<IActionResult> DeleteGroupTranslation(long groupTranslationId)
        {
            await Mediator.Send(new DeleteGroupTranslationCommand { Id = groupTranslationId });

            return NoContent();
        }
    }
}