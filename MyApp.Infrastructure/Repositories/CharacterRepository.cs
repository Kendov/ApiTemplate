using System.Collections.Generic;
using MyApp.Domain.Characters;
using MyApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Infrastructure.Repositories
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        public CharacterRepository(IUnitOfWork unitOfWork, ApiContext context) : base(unitOfWork, context)
        {
        }

        public IEnumerable<Character> FindAll()
        {
            return Dbset.Include(c => c.Items);
        }
    }
}