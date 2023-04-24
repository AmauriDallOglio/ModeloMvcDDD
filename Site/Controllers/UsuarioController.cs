using Dominio.Entidades;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio iUsuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio iUsuario)
        {
            iUsuarioRepositorio = iUsuario;
        }

        public IActionResult Index()
        {
            List<Usuario> resultado = iUsuarioRepositorio.ListarTodos();
            return View(resultado);
        }

        [HttpGet]
        public IActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Incluir(Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(usuario);
                }

                iUsuarioRepositorio.Incluir(usuario);
                TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Incluir");
            }
        }
    }
}
