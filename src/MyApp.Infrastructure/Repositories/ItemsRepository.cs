using System.Collections.Generic;
using System.Linq;
using MyApp.Domain.Items;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories
{
    internal class ItemsRepository : RepositoryBase<Item>, IItemsRepository
    {
        public ItemsRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Item> GetItems(IEnumerable<long> items)
        {
            return Dbset.Where(x => items.Contains(x.Id));
        }

        public bool HasItem(long item)
        {
            return Dbset.Any(x => x.Id == item);
        }

        public bool HasItems(IEnumerable<long> items)
        {
            return Dbset.Where(x => items.Contains(x.Id)).Count() == items.Count();
        }
    }
}
