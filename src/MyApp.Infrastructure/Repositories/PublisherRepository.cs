using MyApp.Domain.Publisher;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories;

internal class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
{
    public PublisherRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

