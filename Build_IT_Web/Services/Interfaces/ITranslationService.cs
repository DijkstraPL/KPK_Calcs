using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Services.Interfaces
{
    public interface ITranslationService
    {
        Task SetScriptsTranslation(string languageCode, IEnumerable<ScriptResource> scriptResources);
        Task SetScriptTranslation(string languageCode, ScriptResource scriptResource);
        Task SetParametersTranslation(string languageCode, IEnumerable<ParameterResource> parametersResource, Language defaultLanguage);
        Task SetParameterTranslation(string languageCode, ParameterResource parameterResource, Language defaultLanguage);
    }
}
