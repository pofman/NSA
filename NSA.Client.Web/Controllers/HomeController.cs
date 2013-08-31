using System.Web.Mvc;
using NailsFramework.UserInterface;

namespace NSA.Client.Web.Controllers
{
    public class HomeController : NailsController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
