using Dominio.Entidades;

namespace Dominio.Interface
{
    public interface ICategoriaRepositorio
    {
        List<Categoria> BuscarTodos();
        Categoria Incluir(Categoria categoria);
        Categoria Alterar(Categoria categoria);
        bool Excluir(int id);
        Categoria BuscarPorId(int id);
    }
}
