using Dominio.Entidades;
using Dominio.Interface;
using Infra.Context;

namespace Infra.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly MeuContext _context;
        public UsuarioRepositorio(MeuContext bancoContext)
        {
            _context = bancoContext;
        }

        public Usuario Incluir(Usuario modal)
        {
            modal.IdentificaQuandoForCadastrado();
            _context.Usuarios.Add(modal);
            _context.SaveChanges();
            return modal;
        }

        public Usuario Alterar(Usuario modal)
        {
            modal.IdentificaQuandoForAlterado();
            _context.Usuarios.Update(modal);
            _context.SaveChanges();
            return modal;
        }
 

        public List<Usuario> ListarTodos()
        {
            List<Usuario> resultados = _context.Usuarios.ToList();
            return resultados;
        }
    }
}
