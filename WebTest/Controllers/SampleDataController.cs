using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts;
using Build_IT_ScriptInterpreter.Scripts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebTest.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<IParameter> Parameters()
        {
            string name = "Compressive strength of concrete at an age";
            var loader = new XmlLoad<Script>();
            var script = loader.LoadData(@"C:\Users\Disseminate\Desktop\Script Interpreter\" + name + ".xml");
            
            return script.Parameters
                .Where(p=>(p.Context & ParameterOptions.Editable) != 0)
                .Select(p=>p);
        }

        [HttpGet("[action]")]
        public IEnumerable<IScript> Scripts()
        {
            var loader = new XmlLoad<Script>();

           var files = Directory.GetFiles(@"C:\Users\Disseminate\Desktop\Script Interpreter\Scripts");
            foreach (var file in files)
            {
                var script = loader.LoadData(file);
                FilterParameters(script);
                yield return script;
            }
        }

        private void FilterParameters(IScript script)
        {
            script.Parameters = script.Parameters
                .Where(p => (p.Context & ParameterOptions.Editable) != 0).OrderBy(p=>p.Number).ToList();
        }

        [HttpGet("[action]/{name}/{parameters}")]
        public IEnumerable<IParameter> Calculate(string name, string parameters)
        {
            var loader = new XmlLoad<Script>();
            var script = loader.LoadData(@"C:\Users\Disseminate\Desktop\Script Interpreter\Scripts\" + name + ".xml");

            var calculationEngine = new CalculationEngine(script);
            calculationEngine.CalculateFromText(parameters);
            
            return script.Parameters
                .Where(p => (p.Context & ParameterOptions.Visible) != 0)
                .Select(p => p); ;
        }

    }
}
