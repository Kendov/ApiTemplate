namespace MyApp.Domain
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qtd { get; set; }
        public virtual Character Character { get; set; }
    }
}