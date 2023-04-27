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
            //builder.Property(x => x.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            //builder.Property(x => x.PrecoVenda).HasColumnName("PrecoVenda").HasColumnType("Money").IsRequired();
            //builder.Property(x => x.Situacao).HasColumnName("Situacao").HasColumnType("short").IsRequired();
            //builder.Property(x => x.DataCadastro).HasColumnName("DataCadastro").HasColumnType("DateTime").IsRequired();
            //builder.Property(x => x.DataAlteracao).HasColumnName("DataAlteracao").HasColumnType("DateTime").IsRequired();

            builder.HasOne(x => x.Categoria);

            //builder.HasKey(t => t.Categoria);
            //builder.Property(d => d.CategoriaId).HasColumnName("CategoriaId").HasColumnType("int").IsRequired();

        }
    }
}
