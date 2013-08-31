using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NSA.Client.Web.Models;
using NailsFramework.IoC;
using NailsFramework.Persistence;
using NailsFramework.UserInterface;
using NSA.Support.Web.Security;

namespace NSA.Client.Web.Controllers
{
    [Support.Web.Security.Authorize(Roles.Users)]
    public class ValuesController : NailsApiController
    {
        [Inject]
        public IBag<Domain.Client> Clients { get; set; }

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
            var client = new Domain.Client(clientDto.Name, clientDto.BirthDate);
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