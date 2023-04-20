using Dominio.Entidades;
using Dominio.Interface;

namespace Aplicacao.Aplicacao
{
    public class ProdutoAplicacao
    {
        private readonly IProdutoRepositorio iProduto;
 
        public ProdutoAplicacao(IProdutoRepositorio iProdutoRepositorio)
        {
            iProduto = iProdutoRepositorio;
      
        }

        public Produto Incluir(Produto produto)
        {
            try
            {
                produto = iProduto.CarregaCategoriaSeExistir(produto);
                Produto resultado = iProduto.Incluir(produto);
                return produto;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }

        //public Produto ConverteEntidade(ProdutoDtoRequestApi produtoApi)
        //{
        //    Produto produto = new Produto();

        //    produto.Descricao = produtoApi.Descricao;
        //    produto.PrecoVenda = produtoApi.PrecoVenda;
        //    produto.Situacao = produtoApi.Situacao;

        //    return produto;

        //}


        public Produto Alterar(Produto produto)
        {
            try
            {
                produto = iProduto.CarregaCategoriaSeExistir(produto);
                Produto resultado = iProduto.Alterar(produto);
                return produto;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }
        }


        public List<Produto> ListarProdutosPorCategoriaPeloNome(string nomeCategoria)
        {
            try
            {
                List<Produto> listadeProdutoPorCategoria = iProduto.ListarProdutosPorCategoriaPeloNome(nomeCategoria);
                if (listadeProdutoPorCategoria.Count == 0)
                    throw new NotImplementedException($"categoria pesquisa não possuí produtos cadastrados!");

                return listadeProdutoPorCategoria;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }
        }

        public List<Produto> ListarProdutosPelaDescricao(string descricao)
        {
            try
            {
                List<Produto> listadeProdutoPorCategoria = iProduto.ListarProdutosPelaDescricao(descricao);
                if (listadeProdutoPorCategoria.Count == 0)
                    throw new NotImplementedException($"não existe produtos com esta descrição!");

                return listadeProdutoPorCategoria;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }
        }


        public List<Produto> ListarProdutoPelaSituacao(bool situacao)
        {
            try
            {
               // short tipo = (short)situacao;
                List<Produto> listadeProdutoPorCategoria = iProduto.ListarProdutosPelaSituacao(situacao);
                if (listadeProdutoPorCategoria.Count == 0)
                    throw new NotImplementedException($"não existe produtos com esta situação!");

                return listadeProdutoPorCategoria;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }
        }


    }
}
