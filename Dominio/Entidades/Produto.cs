using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        //[MaxLength(100)]
        //public string Nome { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        [Display(Name = "Descrição é obrigatório")]
        public string Descricao { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal PrecoVenda { get; set; }
        [Required]
        public bool Situacao { get; set; } 

        [Required]
        [JsonIgnore]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        [Required]
        [JsonIgnore]
        [DataType(DataType.Date)]
        public DateTime DataAlteracao { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }


        public void IdentificaQuandoForGerado()
        {
            DataCadastro = DateTime.Now;
            Situacao = true;

        }


        public void IdentificaQuandoForAlterado()
        {
            DataCadastro = DateTime.Now;
        }



    }
}
