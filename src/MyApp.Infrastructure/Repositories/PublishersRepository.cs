using MyApp.Domain.Publishers;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories;

internal class PublishersRepository : RepositoryBase<Publisher>, IPublishersRepository
{
    public PublishersRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
