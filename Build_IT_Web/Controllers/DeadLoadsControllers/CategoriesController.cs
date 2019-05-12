using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Build_IT_Web.Controllers.DeadLoadsControllers.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Build_IT_Web.Controllers.DeadLoadsControllers
{
    [Route("api/deadloads")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        #region Fields

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        #endregion // Fields
        
        #region Constructors
        
        public CategoriesController(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        #endregion // Constructors

        #region Public_Methods
        
        [HttpGet()]
        public async Task<IEnumerable<CategoryResource>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return _mapper.Map<List<Category>, List<CategoryResource>>(categories.ToList());
        }

        #endregion // Public_Methods
    }
}