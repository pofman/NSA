using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using NSA.Persistence.Initializers;
using NSA.Support.Extensions;

namespace NSA.Persistence
{
    public class NSAContext : DbContext
    {
        public NSAContext(string connectionString)
            : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges());
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            GetType().Assembly.ConcreteSubclassesOf(typeof (StructuralTypeConfiguration<>))
                     .Each(x => modelBuilder.Configurations.Add(Activator.CreateInstance(x) as dynamic));

            base.OnModelCreating(modelBuilder);
        }
    }
}