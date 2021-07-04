using System.Collections.Generic;
using MediatR;

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
}