using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NSA.Domain;
using NSA.Services.Models;
using NSA.Support.Web.Security;
using NailsFramework.IoC;
using NailsFramework.Persistence;
using NailsFramework.UserInterface;

namespace NSA.Services.Controllers
{
    //[Support.Web.Security.Authorize]
    public class ValuesController : NailsApiController
    {
        [Inject]
        public IBag<Client> Clients { get; set; }

        // GET api/values
        public IEnumerable<ClientListItemDto> Get()
        {
            return Clients.Select(x => new ClientListItemDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/clients
        public void Post([FromBody]ClientDto clientDto)
        {
            var client = new Client(clientDto.Name, clientDto.BirthDate);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}