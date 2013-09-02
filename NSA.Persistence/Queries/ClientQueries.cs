using System;
using System.Linq;
using NSA.Domain;
using NSA.Support.Domain;
using NailsFramework.Persistence;

namespace NSA.Persistence.Queries
{
    public static class ClientQueries
    {
         public static IQueryable<Client> ByName(this IQueryable<Client> clients, string name)
         {
             return clients.Where(x => x.Name.Contains(name));
         }
    }

    public static class ModelQueries
    {
        public static IQueryable<TEntity> ById<TEntity>(this IQueryable<TEntity> source, Guid id) where TEntity : Entity<TEntity>
        {
            return source.Where(x => x.Id == id);
        }
    }
}