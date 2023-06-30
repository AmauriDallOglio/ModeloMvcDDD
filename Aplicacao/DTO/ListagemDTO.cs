using Azure.Core.Pipeline;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dominio.Enums.Enums;

namespace Aplicacao.DTO
{
    public class PropostaDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;

        List<PrecoDto> ListaSelecaoProdutos { get; set; }

        List<ProdutoDoGridDto> ListagemProdutos { get; set; }


        public Adesao AdaptarAdesao()
        {
            Adesao adesao = new Adesao();
            adesao.Id = 1;
            adesao.Descricao = "Adesão 1";
            adesao.DataCadastro = DateTime.Now;

            return adesao;
        }
 
        public List<Adesao> AdicionarAdesaoEmLista(Adesao adesao)
        {
            List<Adesao> lista = new List<Adesao>();
            lista.Add(adesao);
            return lista;
        }

        public List<Adesao> RemoverAdesaoEmLista(List<Adesao> listagem, Adesao removerAdesao)
        {
            var lista = listagem.Remove(removerAdesao);
            return listagem;
        }




    }
 


    public class SelecaoProdutos
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }

        public virtual List<PrecoDto>? ListaItemPreco { get; set; }
    }


    public class PrecoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
 
        public virtual List<ItemPrecoDto>? ListaItemPreco { get; set; }
    }

    public class ItemPrecoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }

        public virtual List<ItemPrecoBonusDto>? ListaItemBonusPreco { get; set; }
    }

    public class ItemPrecoBonusDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }

    }


    public class ProdutoDoGridDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }

        public virtual List<Adesao>? ListaAdesao { get; set; }
        public virtual List<AdesaoBonus>? ListaAdesaoBonus { get; set; }



    }


    public class Adesao
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }


    }


    public class AdesaoBonus
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }


    }

    public class Mensalidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
    }
    public class MensalidadeBonus
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
    }


    public class Horas
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
    }

    public class HorasBonus
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
    }

}
