using MyApp.Domain.Common;

namespace MyApp.Domain.Publisher;

public record Publisher : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
}