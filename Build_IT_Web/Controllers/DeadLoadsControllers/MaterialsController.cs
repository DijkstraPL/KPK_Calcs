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
        
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        #endregion // Fields

        #region Constructors
        
        public MaterialsController(
            ICategoryRepository categoryRepository,
            ISubcategoryRepository subcategoryRepository,
            IMaterialRepository materialRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        #endregion // Constructors

        #region Public_Methods
        
        #endregion // Public_Methods
    }
}
