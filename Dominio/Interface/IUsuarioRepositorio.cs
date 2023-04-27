using Dominio.Entidades;

namespace Dominio.Interface
{
    public interface IUsuarioRepositorio
    {
        Usuario Incluir(Usuario modal);
        Usuario Alterar(Usuario modal);
        //Produto CarregaCategoriaSeExistir(Produto produto);

        List<Usuario> ListarTodos();

        Usuario BuscarPorLogin(string login);
        Usuario BuscarPorId(int id);
        //List<Produto> ListarProdutosPelaDescricao(string descricao);
        //List<Produto> ListarProdutosPelaSituacao(bool tipo);

        Usuario BuscarPorEmailELogin(string email, string login);
    }
}
