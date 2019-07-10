using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Translations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.Interfaces
{
    public interface IScriptInterpreterDbContext
    {
        #region Properties

        DbSet<Script> Scripts { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<Parameter> Parameters { get; set; }
        DbSet<Figure> Figures { get; set; }
        DbSet<ScriptTranslation> ScriptsTranslations { get; set; }
        DbSet<ParameterTranslation> ParametersTranslations { get; set; }
        DbSet<ValueOptionTranslation> ValueOptionsTranslations { get; set; }

        #endregion // Properties
    }
}
