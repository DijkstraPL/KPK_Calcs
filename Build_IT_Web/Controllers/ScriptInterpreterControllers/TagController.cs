using AutoMapper;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagController : ControllerBase
    {
        #region Fields
        
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly IScriptInterpreterUnitOfWork _unitOfWork;

        #endregion // Fields

        #region Constructors
        
        public TagController(
            IMapper mapper,
            ITagRepository tagRepository,
            IScriptInterpreterUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion // Constructors

        #region Public_Methods
        
        [HttpGet()]
        public async Task<IActionResult> GetTags()
        {
            var tags = await _tagRepository.GetAllAsync();

            if (tags.Count() == 0)
                return NotFound();

            tags = tags.OrderBy(t => t.Name).ToList();
            var scriptViewModels = _mapper.Map<List<Tag>, List<TagResource>>(tags.ToList());
            return Ok(scriptViewModels);
        }

        [HttpGet("{scriptId}")]
        public async Task<IActionResult> GetTags(long scriptId)
        {
            var tags = await _tagRepository.GetTagsForScript(scriptId);

            if (tags.Count() == 0)
                return NotFound();

            tags = tags.OrderBy(t => t.Name).ToList();
            var scriptViewModels = _mapper.Map<List<Tag>, List<TagResource>>(tags.ToList());
            return Ok(scriptViewModels);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateTag([FromBody] TagResource tagResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tag = _mapper.Map<TagResource, Tag>(tagResource);

            await _tagRepository.AddAsync(tag);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Tag, TagResource>(tag);
            return Ok(result);
        }

        #endregion // Public_Methods
    }
}