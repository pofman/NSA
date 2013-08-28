using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NailsFramework.Persistence;

namespace NSA.Support.Domain
{
    public abstract class Entity<T> : Model<T>, IValidatableObject where T : Model<T>
    {
        public Guid Id { get; protected set; }
        protected Guid TrancientId { get; set; }

        protected Entity()
        {
            Id = TrancientId = IdentityGenerator.NewSequentialGuid();
        }

        public bool IsTrancient
        {
            get { return TrancientId.Equals(Id); }
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}