using AutoMapper;
using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_Web.Controllers.Resources;
using Build_IT_Web.Models;
using Build_IT_Web.Models.Enums;
using Build_IT_Web.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly BuildItDbContext _context;
        private readonly IMapper _mapper;

        public ScriptsController(BuildItDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> GetScripts()
        {
            var scripts = await _context.Scripts.Include(s => s.Tags).ThenInclude(t => t.Tag).ToListAsync();

            if (scripts?.Count == 0)
                return NotFound();

            var scriptViewModels = _mapper.Map<List<Script>, List<ScriptResource>>(scripts);
            return Ok(scriptViewModels);
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScript(long id)
        {
            var script = await _context.Scripts.Include(s => s.Tags).SingleOrDefaultAsync(s => s.Id == id);

            if (script == null)
                return NotFound();

            var scriptViewModel = _mapper.Map<Script, ScriptResource>(script);

            return Ok(scriptViewModel);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateScript([FromBody] ScriptResource scriptViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var script = _mapper.Map<ScriptResource, Script>(scriptViewModel);

            script.Added = DateTime.Now;
            script.Modified = DateTime.Now;
            script.Version = 1.0f;
            _context.Scripts.Add(script);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<Script, ScriptResource>(script);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScript(int id, [FromBody] ScriptResource scriptResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var script = await _context.Scripts.Include(s => s.Tags)
                .SingleOrDefaultAsync(s => s.Id == id);

            if (script == null)
                return NotFound();

            _mapper.Map<ScriptResource, Script>(scriptResource, script);
            script.Modified = DateTime.Now;
            script.Version += 0.1f;

            await _context.SaveChangesAsync();

            var result = _mapper.Map<Script, ScriptResource>(script);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScript(int id)
        {
            var script = await _context.Scripts.FindAsync(id);

            if (script == null)
                return NotFound();

            _context.Remove(script);
            await _context.SaveChangesAsync();

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