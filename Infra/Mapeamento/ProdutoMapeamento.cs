using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infra.Mapeamento
{
    internal class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id).HasName("Id");
            builder.Property(x => x.Descricao).HasColumnName("Descricao").HasMaxLength(100).HasColumnType("varchar").IsRequired();
            builder.HasOne(x => x.Categoria);

            //builder.HasKey(t => t.Categoria);
            //builder.Property(d => d.CategoriaId).HasColumnName("CategoriaId").HasColumnType("int").IsRequired();

        }
    }
}
