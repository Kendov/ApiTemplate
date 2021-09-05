using System.Collections.Generic;
using MyApp.Domain.Items;

namespace MyApp.Domain.Characters
{
    public class Character : BaseEntity
    {
        public Character()
        {
            Items = new HashSet<Item>();
        }

        public string Name { get; set; }
        public CharacterClass Class { get; set; }
        public ICollection<Item> Items { get; init; }

        public string Title => $"{Name} the {Class.ToString("g")}";

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void AddItems(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }
    }
}