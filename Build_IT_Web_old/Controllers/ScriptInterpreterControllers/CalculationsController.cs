using Build_IT_Application.ScriptInterpreter.Calculations.Commands;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/scripts")]
    [ApiController]
    public class CalculationsController : BaseController
    {
        [HttpPut("{scriptId}/calculate/{lang?}")]
        public async Task<ActionResult<IEnumerable<ParameterResource>>> Calculate(
            long scriptId, [FromBody] List<ParameterResource> userParameters, string lang = TranslationService.DefaultLanguageCode)
        {
            var command = new CalculateCommand
            {
                ScriptId = scriptId,
                LanguageCode = lang,
                InputData = userParameters,
            };

            return Ok(await Mediator.Send(command));
        }
    }
}
