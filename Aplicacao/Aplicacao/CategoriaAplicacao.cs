using Aplicacao.Dto;
using Dominio.Entidades;
using Dominio.Interface;
using Infra.Context;
using Microsoft.IdentityModel.Tokens;

namespace Aplicacao.Aplicacao
{
    public class CategoriaAplicacao
    {
        private readonly ICategoriaRepositorio iCategoria;
        public CategoriaAplicacao(ICategoriaRepositorio iCategoriaRepositorio)
        {
            iCategoria = iCategoriaRepositorio;
        }

        public List<Categoria> RetornaTodos()
        {
            List<Categoria> resultado = iCategoria.BuscarTodos();
            return resultado;
        }
        public Categoria BuscarPorId(int id)
        {
            try
            {
                Categoria categoria = iCategoria.BuscarPorId(id);

                if (categoria == null)
                    throw new NotImplementedException("Categoria não foi localizada!");

                return categoria;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Buscar: {erro.Message}");
            }

        }

        //public CategoriaDtoResponseApi BuscarPorIdRetornandoListaProdutos(int id)
        //{
        //    try
        //    {
        //        Categoria categoria = iRepositorioCategoria.BuscarPorId(id);
        //        if (categoria == null)
        //            throw new NotImplementedException("Categoria não foi localizada!");

 

        //        return categoria;
        //    }
        //    catch (Exception erro)
        //    {
        //        throw new NotImplementedException($"Buscar: {erro.Message}");
        //    }

        //}


        public Categoria Incluir(Categoria categoria)
        {
            try
            {
                ValidadorIncluir(categoria);
                Categoria resultado = iCategoria.Incluir(categoria);
                return resultado;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }

        public void ValidadorIncluir(Categoria categoria)
        {
            if (categoria.Descricao.IsNullOrEmpty())
                throw new NotImplementedException("Descrição não pode estar em branco!");
        }

        public Categoria Alterar(Categoria categoria)
        {
            try
            {
                ValidadorAlterar(categoria);
                Categoria resultado = iCategoria.Alterar(categoria);
                return resultado;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }

        }

        private void ValidadorAlterar(Categoria categoria)
        {
            if (categoria.Descricao.IsNullOrEmpty())
                throw new NotImplementedException("descrição não pode estar em branco!");

            if (categoria.DataCadastro.Equals(null))
                throw new NotImplementedException("data não pode ser nula!");

            if (categoria.Situacao < 0)
                throw new NotImplementedException("situação não cadastrada!");
        }


        public bool Excluir(int id)
        {
            try
            {
                bool resultado = iCategoria.Excluir(id);
                return resultado;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Excluir: {erro.Message}");
            }
        }
    }
}
