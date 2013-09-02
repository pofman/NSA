using NSA.Support.Adapter;
using NailsFramework.IoC;
using NailsFramework.UserInterface;

namespace NSA.Client.Web.Controllers
{
    public abstract class BaseNsaApiController : NailsApiController
    {
        [Inject]
        public AdapterManager Adapter { protected get; set; }
    }
}