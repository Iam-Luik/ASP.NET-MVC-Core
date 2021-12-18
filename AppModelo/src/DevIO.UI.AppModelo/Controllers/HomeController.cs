using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.AppModelo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
