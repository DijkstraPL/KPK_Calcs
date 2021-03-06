﻿using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Application.Infrastructures
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
                if (!string.IsNullOrEmpty(scriptTranslation.Name))
                    scriptResource.Name = scriptTranslation.Name;
                if (!string.IsNullOrEmpty(scriptTranslation.Description))
                    scriptResource.Description = scriptTranslation.Description;
                if (!string.IsNullOrEmpty(scriptTranslation.Notes))
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
                if (!string.IsNullOrEmpty(parameterTranslation.Description ))
                    parameterResource.Description = parameterTranslation.Description;
                if (!string.IsNullOrEmpty(parameterTranslation.Notes))
                    parameterResource.Notes = parameterTranslation.Notes;
                if (!string.IsNullOrEmpty(parameterTranslation.GroupName))
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
                if (!string.IsNullOrEmpty(valueOptionTranslation.Name))
                    valueOptionResource.Name = valueOptionTranslation.Name;
                if (!string.IsNullOrEmpty(valueOptionTranslation.Description))
                    valueOptionResource.Description = valueOptionTranslation.Description;
            }
            return;
        }

        #endregion // Public_Methods
    }
}
