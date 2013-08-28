using System.Linq;
using NSA.Domain;

namespace NSA.Persistence.Queries
{
    public static class ClientQueries
    {
         public static IQueryable<Client> ByName(this IQueryable<Client> clients, string name)
         {
             return clients.Where(x => x.Name.Contains(name));
         }
    }
}