using Dominio.Entidades;
using Dominio.Interface;
using Infra.Context;
using Microsoft.IdentityModel.Tokens;

namespace Infra.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly MeuContext _context;
        public ProdutoRepositorio(MeuContext bancoContext)
        {
            _context = bancoContext;
        }

        public Produto Incluir(Produto produto)
        {
            produto.IdentificaQuandoForGerado();
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public Produto Alterar(Produto produto)
        {
            produto.IdentificaQuandoForAlterado();
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }


        public Produto CarregaCategoriaSeExistir(Produto produto)
        {

            var categoriaBanco = new Categoria();
            if (produto.Categoria.Id != 0)
            {
                categoriaBanco = _context.Categorias.Where(a => a.Id == produto.Categoria.Id).FirstOrDefault();
            }
            else
            {
                if (!produto.Categoria.Descricao.IsNullOrEmpty())
                {
                    categoriaBanco = _context.Categorias.Where(a => a.Descricao == produto.Categoria.Descricao).FirstOrDefault();
                }
            }
            if (categoriaBanco != null)
            {
                produto.Categoria = categoriaBanco;
            }

            return produto;
        }

        public List<Produto> ListarProdutosPorCategoriaPeloNome(string nomeCategoria)
        {
            List<Produto> listaDeProdutos = new List<Produto>();
            if (!nomeCategoria.IsNullOrEmpty())
            {
                var retornoBD = _context.Produtos.Where(a => a.Categoria.Descricao.Contains(nomeCategoria)).ToList();
                foreach (var produto in retornoBD)
                {
                    produto.Categoria = _context.Categorias.Where(b => b.Id == produto.CategoriaId).FirstOrDefault();
                    listaDeProdutos.Add(produto);
                }
            }
            return listaDeProdutos;    
        }

        public List<Produto> ListarProdutosPelaDescricao(string descricao)
        {
            List<Produto> listaDeProdutos = new List<Produto>();
            if (!descricao.IsNullOrEmpty())
            {
                var retornoBD = _context.Produtos.Where(a => a.Descricao.Contains(descricao)).ToList();
                foreach (var produto in retornoBD)
                {
                    produto.Categoria = _context.Categorias.Where(b => b.Id == produto.CategoriaId).FirstOrDefault();
                    listaDeProdutos.Add(produto);
                }
            }
            return listaDeProdutos;
        }

        public List<Produto> ListarProdutosPelaSituacao(bool situacao)
        {
            List<Produto> listaDeProdutos = new List<Produto>();
            var retornoBD = _context.Produtos.Where(a => a.Situacao == situacao).ToList();
            foreach (var produto in retornoBD)
            {
                produto.Categoria = _context.Categorias.Where(b => b.Id == produto.CategoriaId).FirstOrDefault();
                listaDeProdutos.Add(produto);
            }
            return listaDeProdutos;
        }


    }
}
