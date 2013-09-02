using System;
using System.Linq.Expressions;
using NSA.Support.Domain;

namespace NSA.Support.Adapter
{
    public abstract class EntityAdapter<TEntity, TContract>
        : ITransformContract
        where TEntity : Entity<TEntity>
        where TContract : class, new()
    {
        public abstract TContract Transform(TEntity source);

        public abstract Expression<Func<TEntity, TContract>> Transform();

        public string Descriptor { get { return string.Format("{0}To{1}", typeof(TEntity).Name, typeof(TContract).Name); } }
    }
}