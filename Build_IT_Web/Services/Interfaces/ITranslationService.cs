using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Services.Interfaces
{
    public interface ITranslationService
    {
        Task SetScriptTranslation(string languageCode, ScriptResource scriptResource);
        Task SetScriptsTranslation(string languageCode, IEnumerable<ScriptResource> scriptResources);
    }
}
