using System.Data.Entity;
using NSA.Domain;
using NSA.Support;

namespace NSA.Persistence.Initializers
{
    public class DropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<NSAContext>
    {
        protected override void Seed(NSAContext context)
        {
            var clients = context.Set<Client>();

            clients.Add(new Client("Juan Topo", SystemDate.Now));
            clients.Add(new Client("Pepe Botella", SystemDate.Now));
        }
    }
}