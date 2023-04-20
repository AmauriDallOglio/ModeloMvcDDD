using Aplicacao.Aplicacao;
using Dominio.Entidades;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;
using static Dominio.Entidades.Enums;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio iProduto;
        private readonly ProdutoAplicacao aplicacaoProduto;
 
 

        public ProdutoController(IProdutoRepositorio iProdutoRepositorio)
        {
            iProduto = iProdutoRepositorio;
            aplicacaoProduto = new ProdutoAplicacao(iProduto);

        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Produto produtoApi)
        {
            try
            {
                Produto produto = aplicacaoProduto.Incluir(produtoApi);
                return Ok(produto); ; //CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
            }
            catch (Exception erro)
            {
                return NotFound("Erro:" + erro.Message);
            }
        }

        [HttpPost("Alterar")]
        public IActionResult Alterar(Produto produto)
        {
            try
            {
                Produto produtoRetorno = aplicacaoProduto.Alterar(produto);
                return Ok(produtoRetorno); ; //CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
            }
            catch (Exception erro)
            {
                return NotFound("Erro:" + erro.Message);
            }
        }

        [HttpGet("ObterPorNomeDaCategoria")]
        public IActionResult ListarPorCategoria(string nome)
        {
            try
            {
                List<Produto> listaDeProdutos = aplicacaoProduto.ListarProdutosPorCategoriaPeloNome(nome);
                return Ok(listaDeProdutos); ; //CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
            }
            catch (Exception erro)
            {
                return NotFound("Erro:" + erro.Message);
            }
        }


        [HttpGet("ObterPorDescricao")]
        public IActionResult ObterPorDescricao(string descricao)
        {
            try
            {
                List<Produto> listaDeProdutos = aplicacaoProduto.ListarProdutosPelaDescricao(descricao);
                return Ok(listaDeProdutos); ; //CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
            }
            catch (Exception erro)
            {
                return NotFound("Erro:" + erro.Message);
            }
        }


        [HttpGet("ObterPelaSituacao")]
        public IActionResult ObterPelaSituacao(SituacaoEnum situacao)
        {
            try
            {
                bool tipo = true;
                if (situacao == SituacaoEnum.Inativo)
                    tipo = false;

                List<Produto> listaDeProdutos = aplicacaoProduto.ListarProdutoPelaSituacao(tipo);
                return Ok(listaDeProdutos); ; //CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
            }
            catch (Exception erro)
            {
                return NotFound("Erro:" + erro.Message);
            }
        }




    }
}
