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
        private readonly IItemsRepository _itemsRepository;
        private readonly IUnitOfWork _unityOfWorks;

        public CreateCharacterCommandHandler(
            ICharactersRepository characterRepository,
            IUnitOfWork unityOfWorks,
            IItemsRepository itemsRepository)
        {
            _characterRepository = characterRepository;
            _unityOfWorks = unityOfWorks;
            _itemsRepository = itemsRepository;
        }

        public Task<Character> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            if (!_itemsRepository.HasItems(request.Items))
            {
                // TODO: Add context validation
                throw new System.ArgumentException();
            }

            var character = new Character
            {
                Class = request.Class,
                Name = request.Name,
                Items = _itemsRepository.GetItems(request.Items).ToList()
            };

            var newEntry = _characterRepository.Insert(character);
            _unityOfWorks.Commit();

            return Task.FromResult(newEntry);
        }
    }

}