using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSA.Services.Controllers;
using NSA.Support;
using NailsFramework.Config;
using NailsFramework.IoC;
using NailsFramework.Logging;
using NailsFramework.Persistence;
using NailsFramework.TestSupport;

namespace NSA.Client.Web.Tests.EntityModelBinder
{
    [TestClass]
    public class EntityModelBinderTests : NailsTests
    {
        [Inject]
        public IBag<Domain.Client> Clients { get; set; }

        private Guid _robertId;
        
        [TestInitialize]
        public void SetUp()
        {
            base.SetUp();

            var client = new Domain.Client("Robert", SystemDate.Now.AddYears(-39));
            
            RunInUnitOfWork(() => Clients.Put(client));

            _robertId = client.Id;
        }

        protected override void ConfigureNails(INailsConfigurator nails)
        {
            nails.InspectAssemblyOf<Domain.Client>()
                 .InspectAssemblyOf<ClientsController>()
                 .IoC.Container<Unity>()
                 .Persistence.DataMapper<Memory>()
                 .Logging.Logger<Log4net>();
        }
        
        public void ShouldBindExistingModel()
        {
        }
    }
}