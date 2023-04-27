using Aplicacao.Filtro;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    [AcessoUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
