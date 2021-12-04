using System.Collections.Generic;
using MyApp.Domain.Characters;
using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories
{
    public class CharactersRepository : RepositoryBase<Character>, ICharactersRepository
    {
        public CharactersRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Character> FindAll()
        {
            return Dbset
                .Include(c => c.Items);
        }
    }
}