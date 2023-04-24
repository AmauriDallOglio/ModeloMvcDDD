using Dominio.Entidades;

namespace Dominio.Interface
{
    public interface IUsuarioRepositorio
    {
        Usuario Incluir(Usuario modal);
        Usuario Alterar(Usuario modal);
        //Produto CarregaCategoriaSeExistir(Produto produto);

        List<Usuario> ListarTodos();

        //List<Produto> ListarProdutosPelaDescricao(string descricao);
        //List<Produto> ListarProdutosPelaSituacao(bool tipo);

    }
}
