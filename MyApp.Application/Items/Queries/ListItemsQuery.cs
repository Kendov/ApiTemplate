using System.Collections.Generic;
using MediatR;
using MyApp.Application.Items.Results;

namespace MyApp.Application.Items.Queries
{
    public class ListItemsQuery : IRequest<IEnumerable<ItemQueryResult>>
    {
    }
}