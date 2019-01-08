using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Build_IT_Web.Controllers.Resources;
using Build_IT_Web.Models;
using Build_IT_Web.Persistance;
using Build_IT_Web.Models.Enums;
using Interpreter = Build_IT_ScriptInterpreter.Scripts;
using Build_IT_ScriptInterpreter.DataSaver;
using System.Collections.ObjectModel;

namespace Build_IT_Web.Controllers
{
    public class ScriptsController : Controller
    {
        private readonly BuildItDbContext _context;
        private readonly IMapper _mapper;

        public ScriptsController(BuildItDbContext context, IMapper mapper)
        {
            _context = context;
           _mapper = mapper;
        }

        [HttpGet("/api/scripts")]
        public async Task<IEnumerable<ScriptResource>> GetScripts()
        {
            var scripts = await _context.Scripts.Include(s => s.Tags).ToListAsync();

            return _mapper.Map<List<Script>, List<ScriptResource>>(scripts);
        }

        [HttpGet("/api/scripts/{id}/parameters")]
        public async Task<IEnumerable<ParameterResource>> GetParameters(int id)
        {
            var parameters = await _context.Parameters
                .Where(p => p.ScriptId == id && (p.Context & ParameterOptions.Editable) != 0)
                .Include(p => p.ValueOptions)
                .Include(p => p.NestedScripts)
                .ToListAsync();

            return _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
        }
        
        [HttpGet("/api/scripts/calculate/{name}/{parameters}")]
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
                    ValueOptions = new Collection<ValueOptionResource>(),
                    ValueOptionSetting = ValueOptionSettings.None,
                    ValueType = (ValueTypes)parameter.ValueType
                };
            }
        }
    }
}