using HotChocolate;
using HotChocolate.Data;
using MyApp.Domain.Characters;
using MyApp.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Infrastructure.GraphQL
{

    internal class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Character> AllCharacters([ScopedService] AppDbContext repository) => repository.Characters;

        // [UseDbContext(typeof(ApiContext))]
        // public IEnumerable<Character> AllCharactersFromRepo([Service] ICharacterRepository characterRepository) => characterRepository.FindAll();

        public Character GetCharacter() =>
            new Character
            {
                Id = 0,
                Class = CharacterClass.Archer,
                Name = "zurik"
            };

        public Character GetCharacterById([Service] ICharactersRepository characterRepository, int id)
        {
            Character gottenEmployee = characterRepository.GetByID(id);
            return gottenEmployee;
        }
    }
}