using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.AppModelo.Modulos.Produtos.Controllers
{
    public class CadastroController : Controller
    {
        [Area("Produtos")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
