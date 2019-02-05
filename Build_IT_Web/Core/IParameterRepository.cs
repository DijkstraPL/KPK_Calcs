using Build_IT_Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Core
{
    public interface IParameterRepository
    {
        Task<List<Parameter>> GetEditableParameters(long id);
        Task<List<Parameter>> GetAllParameters(long id);
    }
}
