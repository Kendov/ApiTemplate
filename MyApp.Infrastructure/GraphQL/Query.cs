using System.Collections.Generic;
using HotChocolate;
using MyApp.Domain;

namespace MyApp.Infrastructure.GraphQL
{
    
    public class Query
    {

        public IEnumerable<Character> AllCharacters([Service]ICharacterRepository characterRepository) =>
            characterRepository.GetAll();
        public Character GetCharacter() =>
            new Character
            {
                Id = 0,
                Class = CharacterClass.Archer,
                Name = "zurik"
            };

        public Character GetCharacterById([Service]ICharacterRepository characterRepository, int id)
        {
            Character gottenEmployee = characterRepository.FindById(id);
            return gottenEmployee;
        }
    }
}