using HotChocolate;
using HotChocolate.Data;
using MyApp.Domain;
using MyApp.Infrastructure.Data;
using System.Linq;

namespace MyApp.Infrastructure.GraphQL
{

    public class Query
    {
        [UseDbContext(typeof(ApiContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Character> AllCharacters([ScopedService]ApiContext context) =>
            context.Characters;

        public Character GetCharacter() =>
            new Character
            {
                Id = 0,
                Class = CharacterClass.Archer,
                Name = "zurik"
            };

        public Character GetCharacterById([Service]ICharacterRepository characterRepository, int id)
        {
            Character gottenEmployee = characterRepository.GetByID(id);
            return gottenEmployee;
        }
    }
}