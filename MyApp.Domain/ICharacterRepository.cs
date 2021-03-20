using System.Collections.Generic;

namespace MyApp.Domain
{
    public interface ICharacterRepository : IRepositoryBase<Character>
    {
        IEnumerable<Character> CustomFindAll();
    }
}