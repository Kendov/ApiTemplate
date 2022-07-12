using HotChocolate;
using HotChocolate.Data;
using MyApp.Domain.Games;
using MyApp.Infrastructure.Data;
using System.Linq;

namespace MyApp.Infrastructure.GraphQL
{

    internal class Query
    {
        // [UseDbContext(typeof(AppDbContext))]
        // [UseProjection]
        // public IQueryable<Game> AllGames([ScopedService] AppDbContext repository) => repository.Games;

        // [UseDbContext(typeof(ApiContext))]
        // public IEnumerable<Game> AllGamesFromRepo([Service] IGameRepository gameRepository) => gameRepository.FindAll();

        // public Game GetGameById([Service] IGamesRepository gameRepository, int id)
        // {
        //     Game game = gameRepository.GetByID(id);
        //     return game;
        // }
    }
}