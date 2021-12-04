using System.Collections.Generic;
using System.Linq;
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
            if (item == null)
            {
                return;
            }

            Items.Add(item);
        }

        public void AddItems(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public void RemoveItem(Item item)
        {
            if (item == null)
            {
                return;
            }

            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }

        public void RemoveItems(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                RemoveItem(item);
            }
        }

        public void ManageItems(IEnumerable<Item> items)
        {
            var itemsToRemove = Items.Where(item => !items.Contains(item));
            var itemsToAdd = items.Where(item => !Items.Contains(item));

            RemoveItems(itemsToRemove);
            AddItems(itemsToAdd);
        }

    }
}