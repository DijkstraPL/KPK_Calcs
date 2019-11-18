using Build_IT_Application.DeadLoads.Subcategories.Queries;
using Build_IT_Application.DeadLoads.Subcategories.Queries.GetAllSubcategories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.DeadLoadsControllers
{
    [Route("api/deadloads")]
    [ApiController]
    public class SubcategoriesController : BaseController
    {
        #region Public_Methods

        [HttpGet("{categoryId}/subcategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SubcategoryResource>>> GetAllSubcategories(long categoryId)
        {
            return Ok(await Mediator.Send(new GetAllSubcategoriesQuery { CategoryId = categoryId }));
        }

        #endregion // Public_Methods
    }
}