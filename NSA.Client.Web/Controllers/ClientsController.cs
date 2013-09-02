using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using NSA.Client.Web;
using NSA.Client.Web.Controllers;
using NSA.Client.Web.Models;
using NSA.Persistence.Queries;
using NSA.Support.Web.ModelBinding;
using NailsFramework.IoC;
using NailsFramework.Persistence;

namespace NSA.Services.Controllers
{
    // [AuthorizationRequired]
    public class ClientsController : BaseNsaApiController
    {
        [Inject]
        public IBag<Domain.Client> Clients { get; set; }

        // GET api/clients
        public IEnumerable<object> Get()
        {
            return Clients.Select(x => new
                {
                    x.Id,
                    x.Name,
                });
        }

        // GET api/clients/5
        public ClientDto Get(Guid id)
        {
            return Clients.ById(id).Select(Adapter.Adapt<Domain.Client, ClientDto>()).FirstOrDefault();
        }

        // POST api/clients
        public void Post([FromBody]ClientDto clientDto)
        {
            var client = new Domain.Client(clientDto.Name, clientDto.BirthDate);
        }

        // PUT api/values/5
        public void Put(Guid id, [FromBody]ClientDto clientDto, [ModelBinder(typeof(EntityModelBinder))]Domain.Client client = null)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}