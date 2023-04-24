using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Dominio.Enums
{
    public class Enums
    {
        public enum SituacaoEnum : int
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

        public enum PerfilEnum
        {
            [Description("Usuario")]
            [Display(Name = "Usuario")]
            [EnumMember(Value = "Usuario")]
            Usuario = 0,
            [Description("Administrador")]
            [Display(Name = "Administrador")]
            [EnumMember(Value = "Administrador")]
            Administrador = 1,
        }

    }
}
