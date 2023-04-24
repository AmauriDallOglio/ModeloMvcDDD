using Aplicacao.Aplicacao;
using Dominio.Entidades;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepositorio iRepositorioCategoria;
        private readonly IProdutoRepositorio iRepositorioProduto;
        private readonly CategoriaAplicacao aplicacaoCategoria;
 
        public CategoriaController(ICategoriaRepositorio iCategoriaRepositorio, IProdutoRepositorio iProdutoRepositorio )
        {
            iRepositorioCategoria = iCategoriaRepositorio;
            iRepositorioProduto = iProdutoRepositorio;
 
            aplicacaoCategoria = new CategoriaAplicacao(iRepositorioCategoria, iRepositorioProduto );
        }

        public IActionResult Index()
        {
            try
            {
                TesteServico serrr = new TesteServico(iRepositorioCategoria, iRepositorioProduto);
                var okk = serrr.Testando();


                List<Categoria> resultado = aplicacaoCategoria.RetornaTodos();
                return View(resultado);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        public IActionResult Grid()
        {
            List<Categoria> resultado = aplicacaoCategoria.RetornaTodos();
            return PartialView("Grid", resultado);
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
                if (!ModelState.IsValid)
                {
                    return View(categoria);
                }

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
                if (!ModelState.IsValid)
                {
                    return View(categoria);
                }

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
