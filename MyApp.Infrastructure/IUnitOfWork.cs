using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure
{
    public interface IUnitOfWork
    {
        ApiContext Context { get; }
        void Commit();
        void RollBack();
    
    }
}