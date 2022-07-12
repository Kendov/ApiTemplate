using System;

namespace MyApp.Domain.Common
{
    public record AuditableEntity : BaseEntity
    {
        // public string CreatedBy { get; init; }
        // public string UpdatedBy { get; init; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public bool IsActive { get; private set; } = true;

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}