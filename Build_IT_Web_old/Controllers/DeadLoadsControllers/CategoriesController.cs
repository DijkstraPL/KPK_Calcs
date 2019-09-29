using Build_IT_Application.DeadLoads.Categories.Queries;
using Build_IT_Application.DeadLoads.Categories.Queries.GetAllCategories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.DeadLoadsControllers
{
    [Route("api/deadloads")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        #region Public_Methods
        
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryResource>>> GetAllCategories()
        {
            return Ok(await Mediator.Send(new GetAllCategoriesQuery()));
        }

        #endregion // Public_Methods
    }
}