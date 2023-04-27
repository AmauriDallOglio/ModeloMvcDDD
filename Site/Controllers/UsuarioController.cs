using Aplicacao.Aplicacao;
using Aplicacao.DTO;
using Aplicacao.Filtro;
using Aplicacao.Interface;
using Dominio.Entidades;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    [AcessoUsuarioLogadoAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _iUsuarioRepositorio;
        private readonly ISessaoAplicacao _iSessaoAplicacao;
        private readonly ILoginAplicacao _iLoginAplicacao;
        public UsuarioController(IUsuarioRepositorio iUsuario, ISessaoAplicacao iSessaoAplicacao, ILoginAplicacao iLoginAplicacao)
        {
            _iUsuarioRepositorio = iUsuario;
            _iSessaoAplicacao = iSessaoAplicacao;
            _iLoginAplicacao = iLoginAplicacao;
        }

        public IActionResult Index()
        {
            List<Usuario> resultado = _iUsuarioRepositorio.ListarTodos();
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

                _iUsuarioRepositorio.Incluir(usuario);
                TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Incluir");
            }
        }

        [HttpPost]
        public IActionResult Alterar(LoginDTO usuario)
        {
            Usuario usuarioLogado = _iSessaoAplicacao.BuscarSessaoDoUsuario();
            try
            {
                if (ModelState.IsValid)
                {
                    var LoginAlterarSenhaDTO = _iLoginAplicacao.ConverterModalParaDto(usuarioLogado);
                    _iLoginAplicacao.AlterarSenha(LoginAlterarSenhaDTO);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", usuarioLogado);
                }

                return View("Index", usuarioLogado);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar sua senha, tente novamante, detalhe do erro: {erro.Message}";
                return View("Index", usuarioLogado);
            }
        }

    }
}
