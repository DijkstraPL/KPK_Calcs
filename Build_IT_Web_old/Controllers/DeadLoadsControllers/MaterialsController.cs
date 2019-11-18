using Build_IT_Application.DeadLoads.Materials.Queries;
using Build_IT_Application.DeadLoads.Materials.Queries.GetAllMaterials;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.DeadLoadsControllers
{
    [Route("api/deadloads")]
    [ApiController]
    public class MaterialsController : BaseController
    {
        #region Public_Methods

        [HttpGet("{subcategoryId}/materials")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MaterialResource>>> GetAllMaterials(long subcategoryId)
        {
            return Ok(await Mediator.Send(new GetAllMaterialsQuery { SubcategoryId = subcategoryId }));
        }

        #endregion // Public_Methods
    }
}
