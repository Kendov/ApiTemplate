using System.Collections.Generic;

namespace MyApp.Domain.Characters
{
    public interface ICharactersRepository : IRepositoryBase<Character>
    {
        IEnumerable<Character> FindAll();
    }
}