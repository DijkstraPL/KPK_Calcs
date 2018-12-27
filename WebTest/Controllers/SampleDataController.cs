using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTest.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private Script _script;

        [HttpGet("[action]")]
        public async Task<IEnumerable<IParameter>> Parameters()
        {
            string name = "Shear resistance without shear reinforcement";
            var loader = new XmlLoad<Build_IT_ScriptInterpreter.DataSaver.SerializableClasses.Script>();
            var scriptData = loader.LoadData(@"C:\Users\Disseminate\Desktop\Beam Statica\" + name + ".xml");

            _script = scriptData.Initialize();

            return _script.Parameters.Where(p => (p.Value.Context & ParameterOptions.Visible) != 0 
            && (p.Value.Context & ParameterOptions.Calculation) == 0)
                .Select(p => p.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Calculate([FromBody] string test)
        {
            return Ok(test);
        }

        [HttpPost]
        public async Task<IActionResult> Calculate([FromBody] IParameter parametersData)
        {
            StringBuilder sb = new StringBuilder();
           // foreach (var parameter in parametersData)
            {

                sb.Append("[")
                  .Append(parametersData.Name)
                  .Append("]")
                  .Append("=")
                  .Append(parametersData.Value)
                  .Append(",");
            }
            sb.Remove(sb.Length - 1, 1);

            _script.CalculateFromText(sb.ToString());

            return Ok(parametersData);
        }
    }
}
