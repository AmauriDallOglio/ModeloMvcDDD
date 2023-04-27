using Dominio.Helper;
using System.ComponentModel.DataAnnotations;
using static Dominio.Enums.Enums;

namespace Dominio.Entidades
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome!")]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o login!")]
        [MaxLength(100)]
        public string Login { get; set;} = string.Empty;
        [Required(ErrorMessage = "Digite a senha!")]
        [MaxLength(100)]
        public string Senha { get; set;} = string.Empty;
        [Required(ErrorMessage = "Digite o email!")]
        [MaxLength(100)]
        public string Email { get; set;} = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataAlteracao { get; set; }
        [Required(ErrorMessage = "Digite o perfil!")]
        public PerfilEnum Perfil { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

        public void IdentificaQuandoForCadastrado()
        {
            DataCadastro = DateTime.Now;
        }


        public void IdentificaQuandoForAlterado()
        {
            DataAlteracao = DateTime.Now;
        }


        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }

    }
}
