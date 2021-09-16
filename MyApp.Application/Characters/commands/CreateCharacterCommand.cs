using System.Collections.Generic;
using MediatR;
using MyApp.Domain.Characters;

namespace MyApp.Application.Characters.Commands
{
    public class CreateCharacterCommand : IRequest<Character>
    {
        public string Name { get; set; }
        public CharacterClass Class { get; set; }
        public ICollection<ItemDTO> Items { get; set; }

        public class ItemDTO
        {
            public string Name { get; set; }
            public int Qtd { get; set; }

        }
    }
}