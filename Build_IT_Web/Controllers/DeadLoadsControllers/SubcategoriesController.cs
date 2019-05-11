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
    public class SubcategoriesController : Controller
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;
        public SubcategoriesController(
            ISubcategoryRepository subcategoryRepository,
            IMapper mapper)
        {
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }

        [HttpGet("{categoryId}/subcategories")]
        public async Task<IEnumerable<SubcategoryResource>> GetAllSubcategories()
        {
            var subcategories = await _subcategoryRepository.GetAllAsync();

            return _mapper.Map<List<Subcategory>, List<SubcategoryResource>>(subcategories.ToList());
        }

    }
}