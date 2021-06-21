using System.Collections.Generic;
using MyApp.Domain.Items;

namespace MyApp.Domain.Characters
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CharacterClass Class { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}