using Dominio.Entidades;
using Dominio.Interface;
using Infra.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infra.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly MeuContext _context;
        public CategoriaRepositorio(MeuContext bancoContext)
        {
            _context = bancoContext;
        }

        public List<Categoria> BuscarTodos()
        {
            var resultados = _context.Categorias.ToList();
            return resultados;
        }
        public Categoria BuscarPorId(int id)
        {
            return _context.Categorias.Where(a => a.Id == id).FirstOrDefault();
        }


        public Categoria Incluir(Categoria categoria)
        {
            categoria.CarregaDadosNoIncluir();
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public Categoria Alterar(Categoria categoria)
        {
            var categoriaBD = BuscarPorId(categoria.Id);
            if (categoriaBD == null)
                throw new System.Exception("Erro na atualização, categoria não localizada!");


            categoriaBD.Descricao = categoria.Descricao;
            //categoriaBD.DataCadastro = categoria.DataCadastro;
            //categoriaBD.Situacao = categoria.Situacao;

            EntityEntry<Categoria> alterar = _context.Categorias.Update(categoriaBD);
            if (alterar.Context == null)
                throw new System.Exception("Não foi possível alterar a categoria!");

            int gravar = _context.SaveChanges();
            if (gravar == 0)
                throw new System.Exception("Não foi possível alterar a categoria, operação cancelada");

            return categoriaBD;
        }
        public bool Excluir(int id)
        {
            var categoriaBD = BuscarPorId(id);
            if (categoriaBD == null)
                throw new System.Exception("Categoria " + id.ToString() + ", não localizada!");

            EntityEntry<Categoria> deletar = _context.Remove(categoriaBD);
            if (deletar.Context == null)
                throw new System.Exception("Não foi possível deletar a categoria!");

            int gravar = _context.SaveChanges();
            if (gravar == 0)
                throw new System.Exception("Não foi possível excluir a categoria, operação cancelada!");

            return true;
        }

    }
}
