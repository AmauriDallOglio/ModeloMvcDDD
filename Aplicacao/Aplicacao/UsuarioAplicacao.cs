using Dominio.Entidades;
using Dominio.Interface;
using Microsoft.IdentityModel.Tokens;

namespace Aplicacao.Aplicacao
{

    public class UsuarioAplicacao
    {

        private readonly IUsuarioRepositorio iUsuario;

        public UsuarioAplicacao(IUsuarioRepositorio iUsuarioRepositorio)
        {
            iUsuario = iUsuarioRepositorio;

        }

        public Usuario Incluir(Usuario usuario)
        {
            try
            {
                ValidadorIncluir(usuario);
                usuario = iUsuario.Incluir(usuario);
                return usuario;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }

        private void ValidadorIncluir(Usuario usuario)
        {
            if (usuario.Nome.IsNullOrEmpty())
                throw new NotImplementedException("Nome não pode estar em branco!");

            if (usuario.Email.Equals(null))
                throw new NotImplementedException("Email não pode ser nulo!");

            if (usuario.Login.IsNullOrEmpty())
                throw new NotImplementedException("Login não poser estar em branco!");

            if (usuario.Senha.IsNullOrEmpty())
                throw new NotImplementedException("Senha não poser estar em branco!");

            if (usuario.Perfil != Dominio.Enums.Enums.PerfilEnum.Usuario || usuario.Perfil != Dominio.Enums.Enums.PerfilEnum.Administrador)
                throw new NotImplementedException("Perfil não poser estar em branco!");

        }
    }
}
