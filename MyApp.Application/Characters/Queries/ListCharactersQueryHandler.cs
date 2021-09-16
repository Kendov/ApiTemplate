using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.Characters.Results;
using MyApp.CrossCutting;
using MyApp.CrossCutting.Extensions;

namespace MyApp.Domain.Characters.Queries
{
    public class ListCharactersQueryHandler : IRequestHandler<ListCharactersQuery, FilteredResult<CharacterQueryResult>>
    {
        private readonly ICharacterRepository _repository;

        public ListCharactersQueryHandler(ICharacterRepository repository)
        {
            _repository = repository;
        }

        Task<FilteredResult<CharacterQueryResult>> IRequestHandler<ListCharactersQuery, FilteredResult<CharacterQueryResult>>.Handle(ListCharactersQuery request, CancellationToken cancellationToken)
        {
            var result = _repository
                .FindAll()
                .Select(x => new CharacterQueryResult
                {
                    Id = x.Id,
                    Name = x.Name,
                    Class = x.Class,
                    Items = x.Items.Select(item => new ItemQueryResult
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Qtd = item.Qtd
                    })
                })
                .Paginate(request.Page, request.PageSize);

            return Task.FromResult(result);
        }
    }
}