using Aplicacao.DTO;
using Aplicacao.Interface;
using Dominio.Entidades;
using Dominio.Interface;

namespace Aplicacao.Aplicacao
{
    public class LoginAplicacao : ILoginAplicacao
    {

        private readonly IUsuarioRepositorio iUsuario;

        public LoginAplicacao(IUsuarioRepositorio iUsuarioRepositorio)
        {
            iUsuario = iUsuarioRepositorio;

        }

        public LoginAlterarSenhaDTO ConverterModalParaDto(Usuario usuario)
        {
            LoginAlterarSenhaDTO dto = new LoginAlterarSenhaDTO();
            dto.Id = usuario.Id;
            dto.Login = usuario.Login;
            dto.SenhaAtual = usuario.Senha;

            return dto;
        }


        public Usuario AlterarSenha(LoginAlterarSenhaDTO alterarSenhaDto)
        {
            Usuario usuarioDB = iUsuario.BuscarPorId(alterarSenhaDto.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");

            if (!usuarioDB.SenhaValida(alterarSenhaDto.SenhaAtual)) throw new Exception("Senha atual não confere!");

            if (usuarioDB.SenhaValida(alterarSenhaDto.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual!");

            usuarioDB.SetNovaSenha(alterarSenhaDto.NovaSenha);
            iUsuario.Alterar(usuarioDB);

            return usuarioDB;


        }

    }
}
