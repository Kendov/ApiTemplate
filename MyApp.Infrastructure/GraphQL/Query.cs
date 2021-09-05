using HotChocolate;
using HotChocolate.Data;
using MyApp.Domain.Characters;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Infrastructure.GraphQL
{

    public class Query
    {
        [UseDbContext(typeof(ApiContext))]
        [UseProjection]
        public IQueryable<Character> AllCharacters([ScopedService] ApiContext repository) => repository.Characters;

        [UseDbContext(typeof(ApiContext))]
        public IEnumerable<Character> AllCharactersFromRepo([Service] ICharacterRepository characterRepository) => characterRepository.FindAll();

        public Character GetCharacter() =>
            new Character
            {
                Id = 0,
                Class = CharacterClass.Archer,
                Name = "zurik"
            };

        public Character GetCharacterById([Service] ICharacterRepository characterRepository, int id)
        {
            Character gottenEmployee = characterRepository.GetByID(id);
            return gottenEmployee;
        }
    }
}