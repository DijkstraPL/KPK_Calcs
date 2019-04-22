using AutoMapper;
using Build_IT_DataAccess.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Controllers
{
    [Route("api/scripts")]
    [ApiController]
    public class ScriptsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IScriptRepository _scriptRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ScriptsController(
            IMapper mapper,
            IScriptRepository scriptRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _scriptRepository = scriptRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<IActionResult> GetScripts()
        {
            var scripts = await _scriptRepository.GetScripts();

            if (scripts?.Count == 0)
                return NotFound();

            var scriptViewModels = _mapper.Map<List<Script>, List<ScriptResource>>(scripts);
            return Ok(scriptViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScript(long id)
        {
            var script = await _scriptRepository.GetScript(id);

            if (script == null)
                return NotFound();

            var scriptViewModel = _mapper.Map<Script, ScriptResource>(script);

            return Ok(scriptViewModel);
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
            _scriptRepository.Add(script);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Script, ScriptResource>(script);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScript(long id, [FromBody] ScriptResource scriptResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var script = await _scriptRepository.GetScript(id);

            if (script == null)
                return NotFound();

            _mapper.Map<ScriptResource, Script>(scriptResource, script);
            script.Modified = DateTime.Now;
            script.Version += 0.1f;

            await _unitOfWork.CompleteAsync();

            script = await _scriptRepository.GetScript(id);

            var result = _mapper.Map<Script, ScriptResource>(script);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScript(long id)
        {
            var script = await _scriptRepository.GetScript(id, includeRelated: false);

            if (script == null)
                return NotFound();

            _scriptRepository.Remove(script);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}