using MyApp.Domain.Characters;

namespace MyApp.Domain.Items
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qtd { get; set; }
        public Character Character { get; set; }
    }
}