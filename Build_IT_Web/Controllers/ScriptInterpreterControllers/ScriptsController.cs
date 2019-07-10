using AutoMapper;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Build_IT_Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/scripts")]
    [ApiController]
    public class ScriptsController : ControllerBase
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;
        private readonly IScriptRepository _scriptRepository;
        private readonly ITranslationService _translationService;
        private readonly IScriptInterpreterUnitOfWork _unitOfWork;

        #endregion // Fields

        #region Constructors

        public ScriptsController(
            IMapper mapper,
            IDateTime dateTime,
            IScriptRepository scriptRepository,
            ITranslationService translationService,
            IScriptInterpreterUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _dateTime = dateTime;
            _scriptRepository = scriptRepository;
            _translationService = translationService;
            _unitOfWork = unitOfWork;
        }

        #endregion // Constructors

        #region Public_Methods

        [HttpGet("{lang?}")]
        public async Task<IActionResult> GetScripts(string lang = null)
        {
            var scripts = await _scriptRepository.GetAllScriptsWithTagsAsync();

            if (scripts?.Count() == 0)
                return NotFound();

            var scriptResources = _mapper.Map<List<Script>, List<ScriptResource>>(scripts.ToList());

            await _translationService.SetScriptsTranslation(lang, scriptResources);

            return Ok(scriptResources);
        }

        [HttpGet("{scriptId}/{lang?}")]
        public async Task<IActionResult> GetScript(long scriptId, string lang = null)
        {
            var script = await _scriptRepository.GetScriptWithTagsAsync(scriptId);

            if (script == null)
                return NotFound();

            var scriptResource = _mapper.Map<Script, ScriptResource>(script);

            await _translationService.SetScriptTranslation(lang, scriptResource);

            return Ok(scriptResource);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateScript([FromBody] ScriptResource scriptResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var script = _mapper.Map<ScriptResource, Script>(scriptResource);

            script.Added = _dateTime.Now;
            script.Modified = _dateTime.Now;
            script.Version = "1";
            await _scriptRepository.AddAsync(script);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Script, ScriptResource>(script);
            return Ok(result);
        }

        [HttpPut("{scriptId}")]
        public async Task<IActionResult> UpdateScript(long scriptId, [FromBody] ScriptResource scriptResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var script = await _scriptRepository.GetScriptWithTagsAsync(scriptId);

            if (script == null)
                return NotFound();

            _mapper.Map<ScriptResource, Script>(scriptResource, script);
            script.Modified = _dateTime.Now;

            await _unitOfWork.CompleteAsync();

            script = await _scriptRepository.GetScriptWithTagsAsync(scriptId);

            var result = _mapper.Map<Script, ScriptResource>(script);
            return Ok(result);
        }

        [HttpDelete("{scriptId}")]
        public async Task<IActionResult> DeleteScript(long scriptId)
        {
            var script = await _scriptRepository.GetAsync(scriptId);

            if (script == null)
                return NotFound();

            _scriptRepository.Remove(script);
            await _unitOfWork.CompleteAsync();

            return Ok(scriptId);
        }

        #endregion // Public_Methods
    }
}