using System.Collections.Generic;
using System.Linq;
using MyApp.Domain;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {

        public IEnumerable<Character> CustomFindAll(){
            var test = Context.Characters.AsEnumerable();
            
            return test;
        }
    }
}