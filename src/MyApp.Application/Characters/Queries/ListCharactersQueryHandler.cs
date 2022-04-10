using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.Items.Results;
using MyApp.CrossCutting;
using MyApp.CrossCutting.Extensions;

namespace MyApp.Domain.Characters.Queries
{
    public class ListCharactersQueryHandler : IRequestHandler<ListCharactersQuery, FilteredResult<ListCharactersQueryResult>>
    {
        private readonly ICharactersRepository _repository;

        public ListCharactersQueryHandler(ICharactersRepository repository)
        {
            _repository = repository;
        }

        Task<FilteredResult<ListCharactersQueryResult>> IRequestHandler<ListCharactersQuery, FilteredResult<ListCharactersQueryResult>>.Handle(ListCharactersQuery request, CancellationToken cancellationToken)
        {
            var result = _repository
                .FindAll()
                .Select(x => new ListCharactersQueryResult
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