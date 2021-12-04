namespace MyApp.Domain
{
    public abstract class BaseEntity : IBaseEntity
    {
        public long Id { get; set; }
    }
}