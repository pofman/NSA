using NSA.Domain;

namespace NSA.Persistence.Mappings
{
    public class ClientEntityTypeConfiguration : BaseEntityTypeConfiguration<Client>
    {
        public ClientEntityTypeConfiguration()
        {
            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.BirthDate).IsRequired();
        }
    }
}