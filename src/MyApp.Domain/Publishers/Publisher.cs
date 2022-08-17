using MyApp.Domain.Common;

namespace MyApp.Domain.Publishers;

public record Publisher : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
}