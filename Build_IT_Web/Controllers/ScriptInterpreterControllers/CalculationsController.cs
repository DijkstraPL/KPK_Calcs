using Build_IT_Application.Infrastructures;
using Build_IT_Application.ScriptInterpreter.Calculations.Commands;
using Build_IT_Application.ScriptInterpreter.Calculations.Queries;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
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
            var query = new CalculateQuery
            {
                ScriptId = scriptId,
                LanguageCode = lang,
                InputData = userParameters,
            };

            return Ok(await Mediator.Send(query));
        }

        [HttpGet("test/{testId}/{assertionId?}/{lang?}")]
        public async Task<ActionResult<bool>> Test(
            long testId, long? assertionId, string lang = TranslationService.DefaultLanguageCode)
        {
            var query = new TestQuery
            {
                TestId = testId,
                LanguageCode = lang,
                AssertionId = assertionId,
            };

            return Ok(await Mediator.Send(query));
        }
    }
}
