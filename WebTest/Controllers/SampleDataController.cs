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

        [HttpGet("[action]")]
        public IEnumerable<Script> Scripts()
        {
            string name1 = "Compressive strength of concrete at an age";
            string name2 = "Shear resistance with shear reinforcement";
            string name3 = "Steel tension";
            var loader = new XmlLoad<Build_IT_ScriptInterpreter.DataSaver.SerializableClasses.Script>();
            var scriptData1 = loader.LoadData(@"C:\Users\Disseminate\Desktop\Script Interpreter\" + name1 + ".xml");
            var scriptData2 = loader.LoadData(@"C:\Users\Disseminate\Desktop\Script Interpreter\" + name2 + ".xml");
            var scriptData3 = loader.LoadData(@"C:\Users\Disseminate\Desktop\Script Interpreter\" + name3 + ".xml");

            var script1 = scriptData1.Initialize();
            var script2 = scriptData2.Initialize();
            var script3 = scriptData3.Initialize();

            yield return script1;
            yield return script2;
            yield return script3;
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
