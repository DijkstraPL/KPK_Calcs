using Build_IT_Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Core
{
    public interface IParameterRepository
    {
        Task<List<Parameter>> GetAllParameters(long scriptId);
        Task<Parameter> GetParameter(long parameterId);
        void Add(Parameter parameter);
        void Remove(Parameter parameter);
    }
}
