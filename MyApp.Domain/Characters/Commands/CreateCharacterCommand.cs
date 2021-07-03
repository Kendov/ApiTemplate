using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain.Items;

namespace MyApp.Domain.Characters.Commands
{
    public class CreateCharacterCommand : IRequest<Character>
    {
        public string Name { get; set; }
        public CharacterClass Class { get; set; }
        public ICollection<ItemDTO> Items { get; set; }

        public class ItemDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Qtd { get; set; }

        }
    }

    public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, Character>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IUnitOfWork _unityOfWorks;

        public CreateCharacterCommandHandler(ICharacterRepository characterRepository, IUnitOfWork unityOfWorks)
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
                    )
                    .ToList(),
                Name = request.Name
            };

            var newEntry = _characterRepository.Insert(character);
            _unityOfWorks.Commit();

            return Task.FromResult(newEntry);
        }
    }

}