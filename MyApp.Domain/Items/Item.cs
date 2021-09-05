using MyApp.Domain.Characters;

namespace MyApp.Domain.Items
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public int Qtd { get; set; }
        public Character Character { get; set; }
    }
}