using MyApp.Domain.Games;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories
{
    internal class GamesRepository : RepositoryBase<Game>, IGamesRepository
    {
        public GamesRepository(AppDbContext context) : base(context)
        {
        }
    }
}