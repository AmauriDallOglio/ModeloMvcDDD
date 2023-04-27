using Aplicacao.DTO;
using Aplicacao.Interface;
using Dominio.Entidades;
using Dominio.Interface;
using Infra.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _iUsuarioRepositorio;
        private readonly ISessaoAplicacao _iSessaoAplicacao;
 

        public LoginController(IUsuarioRepositorio iUsuarioRepositorio,
                               ISessaoAplicacao iSessaoAplicacao)
        {
            _iUsuarioRepositorio = iUsuarioRepositorio;
            _iSessaoAplicacao = iSessaoAplicacao;
    
        }

        public IActionResult Index()
        {
            // Se usuario estiver loago, redirecionar para a home

            if (_iSessaoAplicacao.BuscarSessaoDoUsuario() != null) 
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _iUsuarioRepositorio.BuscarPorLogin(dto.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(dto.SenhaAtual))
                        {
                            _iSessaoAplicacao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha do usuário é inválida, tente novamente.";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        public IActionResult Sair()
        {
            _iSessaoAplicacao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index", "Login");
        }


        public IActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(LoginAlterarSenhaDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _iUsuarioRepositorio.BuscarPorEmailELogin(dto.Email, dto.Login);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";

                        _iUsuarioRepositorio.Alterar(usuario);
                        TempData["MensagemSucesso"] = $"Enviamos para seu e-mail cadastrado uma nova senha.";
               

                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha. Por favor, verifique os dados informados.";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos redefinir sua senha, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
