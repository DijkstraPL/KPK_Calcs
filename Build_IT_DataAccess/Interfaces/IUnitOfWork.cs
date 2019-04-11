using System.Threading.Tasks;

namespace Build_IT_DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
