﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a descrição da categoria!")]
        [MaxLength(50)]
        public string Descricao { get; set; } = string.Empty;
        [Required]
        public short Situacao { get; set; }
        [Required]
        [JsonIgnore]
        public DateTime DataCadastro { get; set; }
        [Required]
        [JsonIgnore]
        public DateTime DataAlteracao { get; set; }
        [JsonIgnore]
        public virtual List<Produto>? Produtos { get; set; }


        public void CarregaDadosNoIncluir()
        {
            DataCadastro = DateTime.Now;
            Situacao = 0;
        }
    }
}
