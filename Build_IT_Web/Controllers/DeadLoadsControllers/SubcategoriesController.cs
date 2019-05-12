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
    public class SubcategoriesController : ControllerBase
    {
        #region Fields
        
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;

        #endregion // Fields

        #region Constructors
        
        public SubcategoriesController(
                ISubcategoryRepository subcategoryRepository,
                IMapper mapper)
        {
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }

        #endregion // Constructors

        #region Public_Methods

        [HttpGet("{categoryId}/subcategories")]
        public async Task<IEnumerable<SubcategoryResource>> GetAllSubcategories(long categoryId)
        {
            var subcategories = await _subcategoryRepository.GetAllSubcategoriesForCategoryAsync(categoryId);

            return _mapper.Map<List<Subcategory>, List<SubcategoryResource>>(subcategories.ToList());
        }

        #endregion // Public_Methods
    }
}