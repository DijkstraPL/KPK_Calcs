using System.Threading.Tasks;

namespace Build_IT_Web.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
