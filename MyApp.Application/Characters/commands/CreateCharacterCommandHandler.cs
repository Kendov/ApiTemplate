using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.Characters.Commands;
using MyApp.Domain;
using MyApp.Domain.Characters;
using MyApp.Domain.Items;

namespace MyApp.Application.CreateCharacters.commands
{
    public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, Character>
    {
        private readonly ICharactersRepository _characterRepository;
        private readonly IUnitOfWork _unityOfWorks;

        public CreateCharacterCommandHandler(ICharactersRepository characterRepository, IUnitOfWork unityOfWorks)
        {
            _characterRepository = characterRepository;
            _unityOfWorks = unityOfWorks;
        }

        public Task<Character> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            var character = new Character
            {
                Class = request.Class,
                Items = request.Items.Select(x =>
                    new Item
                    {
                        Name = x.Name,
                        Qtd = x.Qtd
                    }
                ).ToList(),
                Name = request.Name
            };

            var newEntry = _characterRepository.Insert(character);
            _unityOfWorks.Commit();

            return Task.FromResult(newEntry);
        }
    }

}