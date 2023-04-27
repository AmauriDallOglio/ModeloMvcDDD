using Aplicacao.Interface;
using Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace Aplicacao.Aplicacao
{
    public class SessaoAplicacao : ISessaoAplicacao
    {
        private readonly IHttpContextAccessor _httpContext;
        public SessaoAplicacao(IHttpContextAccessor iHttpContextAccessor)
        {
            _httpContext = iHttpContextAccessor;
        }

        public Usuario BuscarSessaoDoUsuario()
        {
            var sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);

        }

        public void CriarSessaoDoUsuario(Usuario usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }


    }
}
