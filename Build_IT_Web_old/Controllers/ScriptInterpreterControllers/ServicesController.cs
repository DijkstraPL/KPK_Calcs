using Build_IT_Application.Infrastructures;
using Build_IT_Application.ScriptInterpreter.Services.Queries;
using Build_IT_Application.ScriptInterpreter.Services.Queries.GetAllServices;
using Build_IT_Data.Calculators.Interfaces;
using Build_IT_ScriptService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/services")]
    [ApiController]
    public class ServicesController : BaseController
    {
        [HttpGet("{lang?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ServiceResource>>> GetScripts(string lang = TranslationService.DefaultLanguageCode)
        {
            return Ok(await Mediator.Send(new GetAllServicesQuery()));
        }
    }
}
