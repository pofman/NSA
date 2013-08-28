using System.Web.Mvc;
using NailsFramework.UserInterface;

namespace NSA.Services.Controllers
{
    public class HomeController : NailsController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
