using Aplicacao.DTO;
using Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Servicos
{
    public class CategoriaServico
    {
        private readonly IProdutoRepositorio iProduto;
        private readonly ICategoriaRepositorio iCategoria;

        public CategoriaServico(ICategoriaRepositorio iCategoriaRepositorio, IProdutoRepositorio iProdutoRepositorio)
        {
            iProduto = iProdutoRepositorio;
            iCategoria = iCategoriaRepositorio;


        }

        public List<CategoriaDTO> RetornaUmaListaDeCategorias()
        {
            List<CategoriaDTO> lista = new List<CategoriaDTO>();
            return lista;
        }
    }
}
