using System.Collections.Generic;
using MyApp.Domain.Characters;
using MyApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MyApp.Infrastructure
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        public CharacterRepository(IUnitOfWork unitOfWork, ApiContext context) : base(unitOfWork, context)
        {
        }

        public IEnumerable<Character> CustomFindAll(){
            var test = Dbset.ToList();
            
            return test;
        }
    }
}