using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Models.Translations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface ITranslationRepository : IScriptTranslationRepository, 
        IParameterTranslationRepository, IValueOptionTranslationRepository
    {
    }
}
