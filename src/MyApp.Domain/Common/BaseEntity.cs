namespace MyApp.Domain.Common
{
    public abstract record BaseEntity : IBaseEntity
    {
        public long Id { get; init; }

        public bool IsNew => Id == default;
    }
}