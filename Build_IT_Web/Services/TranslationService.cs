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

        public const string DefaultLanguageCode = "en";
        private readonly ITranslationRepository _translationRepository;
        public static readonly Dictionary<string, Language> Languages
            = new Dictionary<string, Language>
            {
                { "en", Language.English },
                { "pl", Language.Polish },
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
            if (Languages.ContainsKey(languageCode) && Languages[languageCode] != scriptResource.DefaultLanguage)
            {
                var scriptTranslation = await _translationRepository.GetScriptTranslation(scriptResource.Id, Languages[languageCode]);
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

        public async Task SetParameterTranslation(string languageCode, ParameterResource parameterResource, Language defaultLanguage)
        {
            if (Languages.ContainsKey(languageCode) && Languages[languageCode] != defaultLanguage)
            {
                var parameterTranslation = await _translationRepository.GetParameterTranslation(parameterResource.Id, Languages[languageCode]);
                if (parameterTranslation == null)
                    return;
                if (parameterTranslation.Description != null)
                    parameterResource.Description = parameterTranslation.Description;
                if (parameterTranslation.Notes != null)
                    parameterResource.Notes = parameterTranslation.Notes;
                if (parameterTranslation.GroupName != null)
                    parameterResource.GroupName = parameterTranslation.GroupName;
                foreach (var valueOption in parameterResource.ValueOptions)
                    await SetValueOptionTranslation(languageCode, valueOption, defaultLanguage);
            }
            return;
        }

        public async Task SetParametersTranslation(string languageCode, IEnumerable<ParameterResource> parametersResource, Language defaultLanguage)
        {
            foreach (var parameterResource in parametersResource)
                await SetParameterTranslation(languageCode, parameterResource, defaultLanguage);
            return;
        }

        public async Task SetValueOptionTranslation(string languageCode, ValueOptionResource valueOptionResource, Language defaultLanguage)
        {
            if (Languages.ContainsKey(languageCode) && Languages[languageCode] != defaultLanguage)
            {
                var valueOptionTranslation = await _translationRepository.GetValueOptionTranslation(valueOptionResource.Id, Languages[languageCode]);
                if (valueOptionTranslation == null)
                    return;
                if (valueOptionTranslation.Name != null)
                    valueOptionResource.Name = valueOptionTranslation.Name;
                if (valueOptionTranslation.Description != null)
                    valueOptionResource.Description = valueOptionTranslation.Description;
            }
            return;
        }

        #endregion // Public_Methods
    }
}
