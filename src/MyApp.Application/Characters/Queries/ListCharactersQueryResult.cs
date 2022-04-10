using System.Collections.Generic;
using System.Linq;
using MyApp.Application.Items.Results;
using MyApp.CrossCutting;
using MyApp.Domain.Characters;
using MyApp.Domain.Items;

namespace MyApp.Domain.Characters.Queries
{
    public class ListCharactersQueryResult
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CharacterClass Class { get; set; }
        public IEnumerable<ItemQueryResult> Items { get; init; }
    }
}