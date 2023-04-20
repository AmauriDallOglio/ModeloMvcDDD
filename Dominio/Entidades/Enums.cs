using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    internal class Enums
    {
        public enum SituacaoEnum
        {
            [Description("Ativo")]
            [Display(Name = "Ativo")]
            [EnumMember(Value = "Ativo")]
            Ativo = 0,
            [Description("Inativo")]
            [Display(Name = "Inativo")]
            [EnumMember(Value = "Inativo")]
            Inativo = 1,
        }

    }
}
