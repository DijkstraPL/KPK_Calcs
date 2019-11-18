using Build_IT_Application.Infrastructures;
using Build_IT_Application.ScriptInterpreter.Calculations.Queries;
using Build_IT_Application.ScriptInterpreter.Calculations.Queries.Calculate;
using Build_IT_Application.ScriptInterpreter.Calculations.Queries.CalculateRange;
using Build_IT_Application.ScriptInterpreter.Calculations.Queries.Test;
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
        [HttpPost("{scriptId}/calculate/{lang?}")]
        public async Task<ActionResult<IEnumerable<ParameterResource>>> Calculate(
            long scriptId, [FromBody] List<CalculateParameterResource> userParameters, string lang = TranslationService.DefaultLanguageCode)
        {
            var query = new CalculateQuery
            {
                ScriptId = scriptId,
                LanguageCode = lang,
                InputData = userParameters,
            };

            return Ok(await Mediator.Send(query));
        }
        [HttpPost("{scriptId}/calculateRange/{lang?}")]
        public async Task<ActionResult<IEnumerable<IEnumerable<ParameterResource>>>> CalculateRange(
         long scriptId, [FromBody] RangeCalculationResource userParameters, string lang = TranslationService.DefaultLanguageCode)
        {
            var query = new CalculateRangeQuery
            {
                ScriptId = scriptId,
                LanguageCode = lang,
                InputData = userParameters,
            };

            return Ok(await Mediator.Send(query));
        }

        [HttpGet("test/{testId}/{assertionId}/{lang?}")]
        public async Task<ActionResult<bool>> Test(
            long testId, long assertionId, string lang = TranslationService.DefaultLanguageCode)
        {
            long? assertionIdFinal = assertionId;
            if(assertionId == -1)
                assertionIdFinal = null;
            
            var query = new TestQuery
            {
                TestId = testId,
                LanguageCode = lang,
                AssertionId = assertionIdFinal,
            };

            return Ok(await Mediator.Send(query));
        }
    }
}
