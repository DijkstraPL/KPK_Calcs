using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Build_IT_Web.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Services
{
    public class TranslationService : ITranslationService
    {
        #region Fields

        public const string DefaultLanguageCode = "GB-en";
        private readonly ITranslationRepository _translationRepository;
        private readonly Dictionary<string, Language> _languages
            = new Dictionary<string, Language>
            {
                { "GB-en", Language.English },
                { "PL-pl", Language.Polish },
            };

        #endregion // Fields

        #region Constructors
        
        public TranslationService(
            ITranslationRepository translationRepository)
        {
            _translationRepository = translationRepository;
        }

        #endregion // Constructors

        #region Public_Methods

        public async Task SetScriptTranslation(string languageCode, ScriptResource scriptResource)
        {
            if (_languages.ContainsKey(languageCode) && _languages[languageCode] != Language.English)
            {
                var scriptTranslation = await _translationRepository.GetScriptTranslation(scriptResource.Id, _languages[languageCode]);
                if (scriptTranslation == null)
                    return;
                if (scriptTranslation.Name != null)
                    scriptResource.Name = scriptTranslation.Name;
                if (scriptTranslation.Description != null)
                    scriptResource.Description = scriptTranslation.Description;
                if (scriptTranslation.Notes != null)
                    scriptResource.Notes = scriptTranslation.Notes;
            }
            return;
        }

        public async Task SetScriptsTranslation(string languageCode, IEnumerable<ScriptResource> scriptResources)
        {
            foreach (var scriptResource in scriptResources)
                await SetScriptTranslation(languageCode, scriptResource);
            return;
        }

        public async Task SetParameterTranslation(string languageCode, ParameterResource parameterResource)
        {
            if (_languages.ContainsKey(languageCode) && _languages[languageCode] != Language.English)
            {
                var parameterTranslation = await _translationRepository.GetParameterTranslation(parameterResource.Id, _languages[languageCode]);
                if (parameterTranslation == null)
                    return;
                if (parameterTranslation.Description != null)
                    parameterResource.Description = parameterTranslation.Description;
                if (parameterTranslation.Notes != null)
                    parameterResource.Notes = parameterTranslation.Notes;
                if (parameterTranslation.GroupName != null)
                    parameterResource.GroupName = parameterTranslation.GroupName;
            }
            return;
        }

        public async Task SetParametersTranslation(string languageCode, IEnumerable<ParameterResource> parametersResource)
        {
            foreach (var parameterResource in parametersResource)
                await SetParameterTranslation(languageCode, parameterResource);
            return;
        }

        public async Task SetValueOptionTranslation(string languageCode, ValueOptionResource valueOptionResource)
        {
            if (_languages.ContainsKey(languageCode) && _languages[languageCode] != Language.English)
            {
                var parameterTranslation = await _translationRepository.GetValueOptionTranslation(valueOptionResource.Id, _languages[languageCode]);
                if (parameterTranslation == null)
                    return;
                if (parameterTranslation.Value != null)
                    valueOptionResource.Value = parameterTranslation.Value;
                if (parameterTranslation.Description != null)
                    valueOptionResource.Description = parameterTranslation.Description;
            }
            return;
        }

        #endregion // Public_Methods
    }
}
