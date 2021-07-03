using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MyApp.Domain.Characters.Commands
{
    public class ListCharactersQuery : IRequest<IEnumerable<Character>>
    {

    }

    public class ListCharactersQueryCommand : IRequestHandler<ListCharactersQuery, IEnumerable<Character>>
    {
        private readonly ICharacterRepository _repository;

        public ListCharactersQueryCommand(ICharacterRepository repository)
        {
            _repository = repository;
        }

        Task<IEnumerable<Character>> IRequestHandler<ListCharactersQuery, IEnumerable<Character>>.Handle(ListCharactersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.Get());
        }
    }
}