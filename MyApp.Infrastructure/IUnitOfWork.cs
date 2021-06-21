using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
    
    }
}