using Dominio.Entidades;

namespace Dominio.Interface
{
    public interface IProdutoRepositorio
    {
        Produto Incluir(Produto produto);
        Produto Alterar(Produto produto);
        Produto CarregaCategoriaSeExistir(Produto produto);

        List<Produto> ListarProdutosPorCategoriaPeloNome(string nomeCategoria);

        List<Produto> ListarProdutosPelaDescricao(string descricao);
        List<Produto> ListarProdutosPelaSituacao(bool tipo);

    }
}
