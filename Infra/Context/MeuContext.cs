using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class MeuContext : DbContext
    {
        public MeuContext(DbContextOptions<MeuContext> options) : base(options) 
        { 
        
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
