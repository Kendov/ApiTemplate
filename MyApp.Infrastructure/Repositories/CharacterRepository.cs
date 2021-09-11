using System.Collections.Generic;
using MyApp.Domain.Characters;
using MyApp.Domain;
using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        public CharacterRepository(IUnitOfWork unitOfWork, AppDbContext context) : base(unitOfWork, context)
        {
        }

        public IEnumerable<Character> FindAll()
        {
            return Dbset
                .Include(c => c.Items);
        }
    }
}