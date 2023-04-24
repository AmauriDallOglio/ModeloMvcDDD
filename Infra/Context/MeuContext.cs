using Dominio.Entidades;
using Infra.Mapeamento;
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
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapeamento());
            base.OnModelCreating(modelBuilder);
        }
    }
}


//use ModeloMvcDDD
//select * from categorias
//select * from Produtos
//select * from usuarios
//--ALTER TABLE usuarios ALTER COLUMN DataAlteracao datetime2 NULL
//--sp_rename 'usuarios.Name', 'Nome', 'COLUMN';