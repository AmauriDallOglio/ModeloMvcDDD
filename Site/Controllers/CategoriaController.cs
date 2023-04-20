using Aplicacao.Aplicacao;
using Dominio.Entidades;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepositorio iRepositorioCategoria;
        private readonly CategoriaAplicacao aplicacaoCategoria;
        public CategoriaController(ICategoriaRepositorio iCategoriaRepositorio)
        {
            iRepositorioCategoria = iCategoriaRepositorio;
            aplicacaoCategoria = new CategoriaAplicacao(iRepositorioCategoria);
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<Categoria> resultado = aplicacaoCategoria.RetornaTodos();
                return View(resultado);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Incluir(Categoria categoria)
        {
            try
            {
                aplicacaoCategoria.Incluir(categoria);
                TempData["MensagemSucesso"] = "Categoria cadastrada com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Incluir");
            }
        }

        [HttpGet]
        public IActionResult Alterar(int id)
        {
            Categoria categoria = aplicacaoCategoria.BuscarPorId(id);
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Alterar(Categoria categoria)
        {
            try
            {
                aplicacaoCategoria.Alterar(categoria);
                TempData["MensagemSucesso"] = "Categoria alterada com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Alterar");
            }
        }

        [HttpGet]
        public IActionResult Apagar(int id)
        {
            Categoria categoria = aplicacaoCategoria.BuscarPorId(id);
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Apagar(Categoria categoria)
        {
            try
            {
                aplicacaoCategoria.Excluir(categoria.Id);
                TempData["MensagemSucesso"] = "Categoria apagada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Excluir");
            }
        }

        [HttpGet]
        public IActionResult Consultar(int id)
        {
            Categoria categoria = aplicacaoCategoria.BuscarPorId(id);
            return View(categoria);
        }
    }
}
