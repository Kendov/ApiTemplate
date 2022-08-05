using System;

namespace MyApp.Domain.Common
{
    public record AuditableEntity : BaseEntity
    {
        // public string CreatedBy { get; init; }
        // public string UpdatedBy { get; init; }

        /// <summary>
        /// Indicates when the entity was created.
        /// The value is changed during the save changes
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Indicates when the entity was updated.
        /// The value is changed during the save changes
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Indicates if the entity is active or not.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Constructor for the class <see cref="AuditableEntity"/>
        /// </summary>
        public AuditableEntity()
        {
            IsActive = true;
        }

        /// <summary>
        /// Deactivates the entity.
        /// </summary>
        public void Deactivate()
        {
            IsActive = false;
        }
    }
}