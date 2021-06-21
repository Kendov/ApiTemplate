using System.Collections.Generic;

namespace MyApp.Domain.Characters
{
    public interface ICharacterRepository : IRepositoryBase<Character>
    {
        IEnumerable<Character> CustomFindAll();
    }
}