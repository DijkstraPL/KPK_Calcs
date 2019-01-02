using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts;
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
            var loader = new XmlLoad<Build_IT_ScriptInterpreter.DataSaver.SerializableClasses.Script>();
            var scriptData = loader.LoadData(@"C:\Users\Disseminate\Desktop\Script Interpreter\" + name + ".xml");

            var script = scriptData.Initialize();

            return script.Parameters
                .Where(p=>(p.Value.Context & ParameterOptions.Editable) != 0)
                .Select(p=>p.Value);
        }

        [HttpGet("[action]/{parameters}")]
        public IEnumerable<IParameter> Calculate(string parameters)
        {
            string name = "Compressive strength of concrete at an age";
            var loader = new XmlLoad<Build_IT_ScriptInterpreter.DataSaver.SerializableClasses.Script>();
            var scriptData = loader.LoadData(@"C:\Users\Disseminate\Desktop\Script Interpreter\" + name + ".xml");

            var script = scriptData.Initialize();

            script.CalculateFromText(parameters);

            return script.Parameters
                .Where(p => (p.Value.Context & ParameterOptions.Visible) != 0)
                .Select(p => p.Value); ;
        }

    }
}
