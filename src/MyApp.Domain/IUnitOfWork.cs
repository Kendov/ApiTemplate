
namespace MyApp.Domain
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
    
    }
}