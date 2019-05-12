using AutoMapper;
using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Build_IT_Web.Controllers.DeadLoadsControllers.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.DeadLoadsControllers
{
    [Route("api/deadloads")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        #region Fields
        
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        #endregion // Fields

        #region Constructors
        
        public MaterialsController(
            IMaterialRepository materialRepository,
            IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        #endregion // Constructors

        #region Public_Methods

        [HttpGet("{subcategoryId}/materials")]
        public async Task<IEnumerable<MaterialResource>> GetAllSubcategories(long subcategoryId)
        {
            var materials = await _materialRepository.GetAllMaterialsForSubcategoryAsync(subcategoryId);

            return _mapper.Map<List<Material>, List<MaterialResource>>(materials.ToList());
        }

        #endregion // Public_Methods
    }
}
