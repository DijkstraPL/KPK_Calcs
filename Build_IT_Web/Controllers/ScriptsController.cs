using AutoMapper;
using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_Web.Controllers.Resources;
using Build_IT_Web.Core;
using Build_IT_Web.Core.Models;
using Build_IT_Web.Core.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Interpreter = Build_IT_ScriptInterpreter.Scripts;

namespace Build_IT_Web.Controllers
{
    [Route("/api/scripts")]
    public class ScriptsController : Controller
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

        [HttpGet("calculate/{name}/{parameters}")]
        public IEnumerable<ParameterResource> Calculate(string name, string parameters)
        {
            //var scr = _context.Scripts.SingleAsync(s => s.Id == scriptId);

            var loader = new XmlLoad<Interpreter.Script>();
            var script = loader.LoadData(@"C:\Users\Disseminate\Desktop\Script Interpreter\Scripts\" + name + ".xml");


            //var scriptBuilder = Interpreter.ScriptBuilder.Create(
            //    script.Name, script.Description, script.Tags.Select(t => t.Name).ToArray());

            //scriptBuilder.SetAuthor(script.Author).SetDescription(script.Description)
            //    .SetDocument(script.AccordingTo).SetGroupName(script.GroupName)

            //foreach (var parameter in script.Parameters)
            //{
            //    scriptBuilder.AppendParameter(new Build_IT_ScriptInterpreter.Parameters.Parameter()
            //    {

            //    })
            //}

            var calculationEngine = new Interpreter.CalculationEngine(script);
            calculationEngine.CalculateFromText(parameters);

            foreach (var parameter in script.Parameters
                .Where(p => (p.Context & Build_IT_ScriptInterpreter.Parameters.ParameterOptions.Visible) != 0 &&
                (p.Context & Build_IT_ScriptInterpreter.Parameters.ParameterOptions.Calculation) != 0))
            {
                yield return new ParameterResource()
                {
                    Name = parameter.Name,
                    Description = parameter.Description,
                    Number = parameter.Number,
                    AccordingTo = parameter.AccordingTo,
                    Context = (ParameterOptions)parameter.Context,
                    DataValidator = parameter.DataValidator?.ToString(),
                    GroupName = parameter.GroupName,
                    Value = parameter.Value?.ToString(),
                    Notes = parameter.Notes,
                    Unit = parameter.Unit,
                    NestedScripts = new Collection<AlternativeScriptResource>(),
                    ValueOptions = new Collection<ValueResource>(),
                    ValueOptionSetting = ValueOptionSettings.None,
                    ValueType = (ValueTypes)parameter.ValueType
                };
            }
        }
    }
}