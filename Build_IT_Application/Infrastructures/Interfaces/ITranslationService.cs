using Build_IT_Application.ScriptInterpreter.Groups.Queries;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries;
using Build_IT_Data.Entities.Scripts.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Application.Infrastructures.Interfaces
{
    public interface ITranslationService
    {
        #region Properties
        
        Task SetScriptsTranslation(string languageCode, IEnumerable<ScriptResource> scriptResources);
        Task SetScriptTranslation(string languageCode, ScriptResource scriptResource);
        Task SetParametersTranslation(string languageCode, IEnumerable<ParameterResource> parametersResource, Language defaultLanguage);
        Task SetParameterTranslation(string languageCode, ParameterResource parameterResource, Language defaultLanguage);
        Task SetGroupsTranslation(string languageCode, IEnumerable<GroupResource> groupResources, Language defaultLanguage);
        Task SetGroupTranslation(string languageCode, GroupResource groupResource, Language defaultLanguage);

        #endregion // Properties
    }
}
