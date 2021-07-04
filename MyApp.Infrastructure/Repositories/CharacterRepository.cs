using System.Collections.Generic;
using MyApp.Domain.Characters;
using MyApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MyApp.Domain;
using MyApp.Domain.Items;

namespace MyApp.Infrastructure.Repositories
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        public CharacterRepository(IUnitOfWork unitOfWork, ApiContext context) : base(unitOfWork, context)
        {
        }

        public IEnumerable<Character> CustomFindAll()
        {
            return Dbset;
        }
    }
}