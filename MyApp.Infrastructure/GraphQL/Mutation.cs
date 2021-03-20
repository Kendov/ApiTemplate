using System.Threading.Tasks;
using HotChocolate;
using MyApp.Domain;

namespace MyApp.Infrastructure.GraphQL
{
    public class Mutation
    {

        public Task<Character> CreateCharacter([Service]ICharacterRepository characterRepository, Character character)
        {
            return Task.FromResult(characterRepository.Add(character));
        }

    }
}