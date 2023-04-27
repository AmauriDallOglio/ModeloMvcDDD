using Aplicacao.DTO;
using Dominio.Entidades;

namespace Aplicacao.Interface
{
    public interface ILoginAplicacao
    {
        LoginAlterarSenhaDTO ConverterModalParaDto(Usuario usuario);
        Usuario AlterarSenha(LoginAlterarSenhaDTO alterarSenhaDto);
    }
}
