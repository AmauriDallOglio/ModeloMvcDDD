using Dominio.Entidades;
using static Dominio.Enums.Enums;

namespace Aplicacao.DTO
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public SituacaoEnum Situacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public virtual List<Produto>? Produtos { get; set; }
    }

    public class CategoriaChamadaApi
    {
        public int Id { get; set; }
    }

    public class CategoriaRetornoApi
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public SituacaoEnum Situacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public virtual List<Produto>? Produtos { get; set; }
    }
}
