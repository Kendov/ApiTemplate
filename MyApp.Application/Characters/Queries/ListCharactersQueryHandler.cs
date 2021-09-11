using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.CrossCutting;
using MyApp.CrossCutting.Extensions;

namespace MyApp.Domain.Characters.Queries
{
    public class ListCharactersQueryHandler : IRequestHandler<ListCharactersQuery, FilteredResult<Character>>
    {
        private readonly ICharacterRepository _repository;

        public ListCharactersQueryHandler(ICharacterRepository repository)
        {
            _repository = repository;
        }

        Task<FilteredResult<Character>> IRequestHandler<ListCharactersQuery, FilteredResult<Character>>.Handle(ListCharactersQuery request, CancellationToken cancellationToken)
        {
            var result = _repository
                .FindAll()
                .Paginate(request.Page, request.PageSize);

            return Task.FromResult(result);
        }
    }
}