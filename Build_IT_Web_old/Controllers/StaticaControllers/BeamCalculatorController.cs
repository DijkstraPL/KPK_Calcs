using Build_IT_Application.DeadLoads.Materials.Queries;
using Build_IT_Application.DeadLoads.Materials.Queries.GetAllMaterials;
using Build_IT_Application.Statica.Calculations;
using Build_IT_Application.Statica.Calculations.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.DeadLoadsControllers
{
    [Route("api/beam")]
    [ApiController]
    public class BeamCalculatorController : BaseController
    {
        #region Public_Methods

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllMaterials([FromBody] BeamDataResource beamDataResource)
        {
            var command = new CalculateBeamCommand
            {
                InputData = beamDataResource
            };

            return Ok(await Mediator.Send(command));
        }

        #endregion // Public_Methods
    }
}
