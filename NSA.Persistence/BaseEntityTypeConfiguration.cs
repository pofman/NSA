using System.Data.Entity.ModelConfiguration;
using NSA.Support.Domain;

namespace NSA.Persistence
{
    public abstract class BaseEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : Entity<T>
    {
        protected BaseEntityTypeConfiguration ()
        {
            ConfigureId();
        }

        protected virtual void ConfigureId()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
        }
    }
}