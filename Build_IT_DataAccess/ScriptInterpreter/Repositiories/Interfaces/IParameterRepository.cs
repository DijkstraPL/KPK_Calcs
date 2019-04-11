using Build_IT_DataAccess.ScriptInterpreter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface IParameterRepository
    {
        Task<List<Parameter>> GetAllParameters(long scriptId);
        Task<Parameter> GetParameter(long parameterId);
        void Add(Parameter parameter);
        void Remove(Parameter parameter);
    }
}
