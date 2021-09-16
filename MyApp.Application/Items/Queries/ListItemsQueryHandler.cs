using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.Items.Results;
using MyApp.Domain.Items;

namespace MyApp.Application.Items.Queries
{
    public class ListItemsQueryHandler : IRequestHandler<ListItemsQuery, IEnumerable<ItemQueryResult>>
    {
        private readonly IItemsRepository _itemsRepository;

        public ListItemsQueryHandler(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public Task<IEnumerable<ItemQueryResult>> Handle(ListItemsQuery request, CancellationToken cancellationToken)
        {
            var result = _itemsRepository.Get().Select(x => new ItemQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Qtd = x.Qtd
            });

            return Task.FromResult(result);
        }
    }
}