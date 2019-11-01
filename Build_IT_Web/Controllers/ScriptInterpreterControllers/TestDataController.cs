using Build_IT_Application.Infrastructures;
using Build_IT_Application.ScriptInterpreter.Scripts.Commands.CreateScript;
using Build_IT_Application.ScriptInterpreter.Scripts.Commands.DeleteScript;
using Build_IT_Application.ScriptInterpreter.Scripts.Commands.UpdateScript;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries.GetAllScripts;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries.GetScript;
using Build_IT_Application.ScriptInterpreter.TestDatas.Commands.CreateTestData;
using Build_IT_Application.ScriptInterpreter.TestDatas.Commands.DeleteTestData;
using Build_IT_Application.ScriptInterpreter.TestDatas.Queries.GetTestDatasForScript;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/testData")]
    [ApiController]
    public class TestDataController : BaseController
    {
        [HttpGet("{scriptId}/{lang?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ScriptResource>>> GetTestDatas(long scriptId, string lang = TranslationService.DefaultLanguageCode)
        {
            return Ok(await Mediator.Send(new GetTestDatasForScriptQuery { ScriptId = scriptId, Language = lang } ));
        }

        [HttpPost("{scriptId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize()]
        public async Task<IActionResult> Create(long scriptId, [FromBody]CreateTestDataCommand command)
        {
            command.ScriptId = scriptId;
            return Ok(await Mediator.Send(command));
        }

        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize()]
        //public async Task<IActionResult> UpdateScript([FromBody]UpdateScriptCommand command)
        //{
        //    await Mediator.Send(command);

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize()]
        public async Task<IActionResult> Delete(long id)
        {
            await Mediator.Send(new DeleteTestDataCommand { Id = id });

            return NoContent();
        }
    }
}