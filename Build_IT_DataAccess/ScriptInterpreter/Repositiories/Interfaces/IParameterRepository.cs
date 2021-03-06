﻿using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface IParameterRepository : IRepository<Parameter>
    {
        #region Public_Methods
        
        Task<IEnumerable<Parameter>> GetAllParametersForScriptAsync(long scriptId);
        Task<Parameter> GetParameterWithAllDependanciesAsync(long parameterId);
        Task<IEnumerable<Figure>> GetFiguresAsync(long parameterId);

        #endregion // Public_Methods
    }
}
