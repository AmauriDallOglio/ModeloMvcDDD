using Dominio.Entidades;

namespace Aplicacao.Interface
{
    public interface ISessaoAplicacao
    {
        void CriarSessaoDoUsuario(Usuario usuario);
        void RemoverSessaoDoUsuario();
        Usuario BuscarSessaoDoUsuario();
    }
}
