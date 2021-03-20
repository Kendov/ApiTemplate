using System.Collections.Generic;

namespace MyApp.Domain
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CharacterClass Class { get; set; }
        public virtual IEnumerable<Items> Items { get; set; }
    }
}