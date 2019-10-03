using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_Desktop.Data.Interfaces
{
    public interface IRequest<T> where T : class
    {
        Task<T> Execute();
    }
}
