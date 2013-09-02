using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using NSA.Support.Domain;
using NSA.Support.Extensions;
using NailsFramework.Config;
using NailsFramework.IoC;
using NailsFramework.Support;

namespace NSA.Support.Adapter
{
    [Lemming]
    public class AdapterManager
    {
        private Dictionary<string, ITransformContract> Contracts { get; set; }

        [Inject]
        public AssembliesToInspect AssembliesToInspect { private get; set; }

        public AdapterManager()
        {
            Initialize();
        }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void Initialize()
        {
            Contracts =
                AssembliesToInspect.ConcreteSubclassesOf<ITransformContract>()
                                   .AsParallel()
                                   .Select(x => (ITransformContract) Activator.CreateInstance(x))
                                   .ToDictionary(x => x.Descriptor, x => x);
        }

        public ITransformContract Get<TEntity, TContract>()
            where TEntity : Entity<TEntity>
            where TContract : class
        {
            return Contracts.First(x => x.Key == string.Format("{0}To{1}",typeof(TEntity).Name, typeof(TContract).Name)).Value;
        }

        public TContract Adapt<TEntity, TContract>(TEntity source) 
            where TEntity : Entity<TEntity>
            where TContract : class, new()
        {
            return Get<TEntity, TContract>().As<EntityAdapter<TEntity, TContract>>().Transform(source);
        }
        
        public Expression<Func<TEntity, TContract>> Adapt<TEntity, TContract>()
            where TEntity : Entity<TEntity>
            where TContract : class, new()
        {
            return Get<TEntity, TContract>().As<EntityAdapter<TEntity, TContract>>().Transform();
        }
    }
}