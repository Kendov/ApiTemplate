
using System.Threading.Tasks;

namespace MyApp.Domain
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        void RollBack();

    }
}