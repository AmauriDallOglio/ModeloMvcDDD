using System.ComponentModel.DataAnnotations;

namespace Aplicacao.DTO
{
    public class LoginDTO
    {
        
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }

       
        [Required(ErrorMessage = "Digite a senha atual do usuário")]
        public string SenhaAtual { get; set; }
 
    }


    public class LoginAlterarSenhaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Digite a senha atual do usuário")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Digite a nova senha do usuário")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme a nova senha do usuário")]
        [Compare("NovaSenha", ErrorMessage = "Senha não confere com a nova senha")]
        public string ConfirmarNovaSenha { get; set; }
    }


}
