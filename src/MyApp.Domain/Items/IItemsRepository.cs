using System.Collections.Generic;

namespace MyApp.Domain.Items
{
    public interface IItemsRepository : IRepositoryBase<Item>
    {
        bool HasItem(long item);
        bool HasItems(IEnumerable<long> item);
        IEnumerable<Item> GetItems(IEnumerable<long> items);
    }
}