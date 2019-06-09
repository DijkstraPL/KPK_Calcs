using AutoMapper;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/scripts")]
    [ApiController]
    public class ScriptsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IScriptRepository _scriptRepository;
        private readonly IScriptInterpreterUnitOfWork _unitOfWork;

        public ScriptsController(
            IMapper mapper,
            IScriptRepository scriptRepository,
            IScriptInterpreterUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _scriptRepository = scriptRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<IActionResult> GetScripts()
        {
            var scripts = await _scriptRepository.GetAllScriptsWithTagsAsync();

            if (scripts?.Count() == 0)
                return NotFound();

            var scriptViewModels = _mapper.Map<List<Script>, List<ScriptResource>>(scripts.ToList());
            return Ok(scriptViewModels);
        }

        [HttpGet("{scriptId}")]
        public async Task<IActionResult> GetScript(long scriptId)
        {
            var script = await _scriptRepository.GetScriptWithTagsAsync(scriptId);

            if (script == null)
                return NotFound();

            var scriptResource = _mapper.Map<Script, ScriptResource>(script);

            return Ok(scriptResource);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateScript([FromBody] ScriptResource scriptResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var script = _mapper.Map<ScriptResource, Script>(scriptResource);

            script.Added = DateTime.Now;
            script.Modified = DateTime.Now;
            script.Version = 1.0f;
            _scriptRepository.AddAsync(script);
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
            script.Modified = DateTime.Now;
            script.Version += 0.1f;

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
    }
}