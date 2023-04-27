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
            modal.SetSenhaHash();
            _context.Usuarios.Add(modal);
            _context.SaveChanges();
            return modal;
        }

        public Usuario Alterar(Usuario modal)
        {
            modal.IdentificaQuandoForAlterado();
            //modal.SetNovaSenha(modal.NovaSenha);
            _context.Usuarios.Update(modal);
            _context.SaveChanges();
            return modal;
        }
 

        public List<Usuario> ListarTodos()
        {
            List<Usuario> resultados = _context.Usuarios.ToList();
            return resultados;
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(a => a.Login == login);
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(a => a.Id == id);
        }

        public Usuario BuscarPorEmailELogin(string email, string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }


        //public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        //{
        //    UsuarioModel usuarioDB = BuscarPorID(alterarSenhaModel.Id);

        //    if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");

        //    if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere!");

        //    if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual!");

        //    usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
        //    usuarioDB.DataAtualizacao = DateTime.Now;

        //    _context.Usuarios.Update(usuarioDB);
        //    _context.SaveChanges();

        //    return usuarioDB;
        //}
    }
}
