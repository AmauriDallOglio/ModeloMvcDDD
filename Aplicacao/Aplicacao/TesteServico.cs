using Dominio.Entidades;
using Dominio.Interface;
using Infra.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

namespace Aplicacao.Aplicacao
{
 
    public class TesteServico
    {

        private readonly IProdutoRepositorio iProduto;
        private readonly ICategoriaRepositorio iCategoria;

        public TesteServico(ICategoriaRepositorio iCategoriaRepositorio, IProdutoRepositorio iProdutoRepositorio)
        {
            iProduto = iProdutoRepositorio;
            iCategoria = iCategoriaRepositorio;

        }

        public List<Produto> Testando()
        {
            List<Produto> lista = new List<Produto>();
            return lista;
        }

    }
}
